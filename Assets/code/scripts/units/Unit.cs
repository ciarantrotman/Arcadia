using System;
using code.scripts.input;
using code.scripts.interfaces;
using code.scripts.objects;
using Pathfinding;
using Sirenix.OdinInspector;
using UnityEngine;

namespace code.scripts.units {
    [RequireComponent(typeof(Seeker)), RequireComponent(typeof(IAstarAI))]
    public abstract class Unit : MonoBehaviour, Interfaces.ISelect {
        [InlineEditor(InlineEditorModes.FullEditor), SerializeField] protected internal UnitData data;

        [SerializeField] private bool moveToCursor;
        
        private Seeker seeker;
        private IAstarAI pathfinder;

        private void Awake() {
            seeker = GetComponent<Seeker>();
            pathfinder = GetComponent<IAstarAI>();
        }

        private void Start() {
            RegisterUnit();
        }

        private void Update() {
            if (moveToCursor) {
                pathfinder.destination = CursorManager.world_position();
            }
        }

        private void OnDisable() {
            DeregisterUnit();
        }

        private void RegisterUnit() {
            UnitManager.RegisterUnit(this);
        }
        
        private void DeregisterUnit() {
            UnitManager.DeregisterUnit(this);
        }
        
        public void Select() {
            UnitManager.SelectUnit(this);
        }

        public void Deselect() {
            UnitManager.DeselectUnit(this);
        }
    }
}