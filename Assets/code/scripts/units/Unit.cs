using BehaviorDesigner.Runtime;
using code.scripts.objects;
using code.scripts.tilemap.managers;
using code.scripts.tilemap.utilities;
using Pathfinding;
using Sirenix.OdinInspector;
using UnityEngine;
using static code.scripts.interfaces.Interfaces;
using static code.scripts.tilemap.utilities.HexagonUtilities;

namespace code.scripts.units {
    [RequireComponent(typeof(Seeker)), RequireComponent(typeof(IAstarAI)), RequireComponent(typeof(OutlinedObject))]
    public abstract class Unit : MonoBehaviour, ISelect, IMove {
        [InlineEditor(InlineEditorModes.GUIAndPreview), SerializeField] protected internal UnitData data;
        
        protected internal IAstarAI pathfinder;
        private OutlinedObject unit_outline;
        private BehaviorTree unit_behavior_tree;
        
        public Vector3Int OffsetCoordinates => GridManager.GetCellCoordinate(transform.position);
        public CubicCoordinates CubicCoordinates => OffsetCoordinates.offset_to_cubic();

        private void Awake() {
            pathfinder = GetComponent<IAstarAI>();
            unit_outline = GetComponent<OutlinedObject>();
            unit_behavior_tree = GetComponent<BehaviorTree>();
        }

        private void Start() => UnitManager.RegisterUnit(this);
        private void OnEnable() => UnitManager.RegisterUnit(this);
        private void OnDisable() => UnitManager.DeregisterUnit(this);
        public void Select() {
            UnitManager.SelectUnit(this);
            unit_outline.SetOutlineOverrideState(true);
        }
        public void Deselect() {
            UnitManager.DeselectUnit(this);
            unit_outline.SetOutlineOverrideState(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cubic_coordinates"></param>
        public void OrderMovement(Vector3Int cubic_coordinates) {
            unit_behavior_tree.SendEvent<object>("OrderMovement", cubic_coordinates);
            SetPathfinderDestination(cubic_coordinates);
        }
        /// <summary>
        /// This is called any time the move command is set, it will update the destination even if the MoveToCubicCoordinates
        /// behavior node is running
        /// </summary>
        /// <param name="cubic_coordinates"></param>
        public void SetPathfinderDestination(Vector3Int cubic_coordinates) {
            pathfinder.destination = GridManager.GetWorldPosition(cubic_coordinates);
            pathfinder.SearchPath();
        }
    }
}