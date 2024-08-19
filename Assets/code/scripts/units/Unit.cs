using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using code.scripts.outline;
using code.scripts.tilemap.managers;
using code.scripts.tilemap.utilities;
using Pathfinding;
using Sirenix.OdinInspector;
using UnityEngine;
using static code.scripts.interfaces.Interfaces;
using static code.scripts.tilemap.utilities.HexagonUtilities;

namespace code.scripts.units {
    [RequireComponent(typeof(Seeker)), RequireComponent(typeof(IAstarAI)), RequireComponent(typeof(OutlinedObject))]
    public abstract class Unit : MonoBehaviour, ISelect, IMove, IInspect {
        [InlineEditor(InlineEditorModes.GUIAndPreview), SerializeField] protected internal UnitData data;
        [SerializeField] private bool exclusiveSelection;
        
        protected internal IAstarAI pathfinder;
        private OutlinedObject unit_outline;
        private BehaviorTree unit_behavior_tree;
        
        public List<CubicCoordinates> traversable_cells_in_range => GridManager.valid_coordinates_in_range(transform.cubic_coordinates(), data.vision.range); // todo take into account blocked cells

        private void Awake() {
            pathfinder = GetComponent<IAstarAI>();
            unit_outline = GetComponent<OutlinedObject>();
            unit_behavior_tree = GetComponent<BehaviorTree>();
        }

        private void Start() => UnitManager.RegisterUnit(this);
        private void OnEnable() => UnitManager.RegisterUnit(this);
        private void OnDisable() => UnitManager.DeregisterUnit(this);

        public bool exclusive_selection {
            get => exclusiveSelection;
            set => exclusiveSelection = value;
        }

        public bool selected { get; set; }

        public void Select() {
            selected = true;
            UnitManager.SelectUnit(this);
            unit_outline.SetOutlineOverrideState(true);
        }
        public void Deselect() {
            selected = false;
            UnitManager.DeselectUnit(this);
            unit_outline.SetOutlineOverrideState(false);
        }
        /// <summary>
        /// Triggers the unit to move to the defined coordinates
        /// </summary>
        /// <param name="offset_coordinates"></param>
        public void OrderMovement(Vector3Int offset_coordinates) {
            unit_behavior_tree.SendEvent<object>("OrderMovement", offset_coordinates);
            SetPathfinderDestination(offset_coordinates);
            Debug.Log($"<b>{name}</b>: {data.information.name} has been ordered to move to {offset_coordinates.readable_label()}");
        }
        /// <summary>
        /// This is called any time the move command is set, it will update the destination even if the MoveToCubicCoordinates
        /// behavior node is running
        /// </summary>
        /// <param name="offset_coordinates"></param>
        public void SetPathfinderDestination(Vector3Int offset_coordinates) {
            pathfinder.destination = GridManager.get_world_position(offset_coordinates);
            pathfinder.SearchPath();
        }
        public void Inspect() => Debug.Log($"<b>{name}</b>: {data.information.name} has been inspected");
    }
}