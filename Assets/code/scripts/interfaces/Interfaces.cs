using UnityEngine;
using UnityEngine.Events;

namespace code.scripts.interfaces {
    public interface Interfaces {
        interface ISelect {
            public bool exclusive_selection  { get; set; }
            public bool selected  { get; set; }
            /// <summary>
            /// 
            /// </summary>
            void Select();
            /// <summary>
            /// 
            /// </summary>
            void Deselect();
        }
        interface IInteract {
            void TriggerInteraction();
            void FinishInteraction();
        }
        interface IMove {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="cubic_coordinates"></param>
            void OrderMovement(Vector3Int cubic_coordinates);
            /// <summary>
            /// 
            /// </summary>
            /// <param name="offset_coordinates"></param>
            void SetPathfinderDestination(Vector3Int offset_coordinates);
        }
        interface IInspect {
            /// <summary>
            /// 
            /// </summary>
            void Inspect();
        }
        public interface IOutline {
            /// <summary>
            /// 
            /// </summary>
            internal SpriteRenderer target { get; set; }
            /// <summary>
            /// 
            /// </summary>
            internal SpriteRenderer subject { get; set; }
            /// <summary>
            /// 
            /// </summary>
            internal bool outline_state_override { get; set; }
            /// <summary>
            /// 
            /// </summary>
            void InitialiseOutline();
            /// <summary>
            /// 
            /// </summary>
            /// <param name="state"></param>
            void SetOutlineState(bool state);
            /// <summary>
            /// 
            /// </summary>
            /// <param name="state"></param>
            void SetOutlineOverrideState(bool state);
        }
    }
}