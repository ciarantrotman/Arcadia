using BehaviorDesigner.Runtime;
using code.scripts.tilemap.managers;
using code.scripts.tilemap.utilities;
using Pathfinding;
using Sirenix.OdinInspector;
using UnityEngine;
using static code.scripts.interfaces.Interfaces;
using static code.scripts.tilemap.utilities.HexagonUtilities;

namespace code.scripts.units {
    [RequireComponent(typeof(Seeker)), RequireComponent(typeof(IAstarAI))]
    public abstract class Unit : MonoBehaviour, ISelect, IMove {
        [InlineEditor(InlineEditorModes.GUIAndPreview), SerializeField] protected internal UnitData data;
        
        protected internal IAstarAI pathfinder;
        private BehaviorTree unit_behavior_tree;
        
        public Vector3Int OffsetCoordinates => GridManager.GetCellCoordinate(transform.position);
        public CubicCoordinates CubicCoordinates => OffsetCoordinates.offset_to_cubic();

        private void Awake() {
            pathfinder = GetComponent<IAstarAI>();
            unit_behavior_tree = GetComponent<BehaviorTree>();
        }

        private void Start() => UnitManager.RegisterUnit(this);
        private void OnEnable() => UnitManager.RegisterUnit(this);
        private void OnDisable() => UnitManager.DeregisterUnit(this);
        public void Select() => UnitManager.SelectUnit(this);
        public void Deselect() => UnitManager.DeselectUnit(this);
        public void OrderMovement(Vector3Int cubic_coordinates) => unit_behavior_tree.SendEvent<object>("OrderMovement", cubic_coordinates);
    }
}