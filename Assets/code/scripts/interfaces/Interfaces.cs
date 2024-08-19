using UnityEngine;
using UnityEngine.Events;

namespace code.scripts.interfaces {
    public interface Interfaces {
        /// <summary>
        /// 
        /// </summary>
        interface ISelect {
            /// <summary>
            /// 
            /// </summary>
            void Select();
            /// <summary>
            /// 
            /// </summary>
            void Deselect();
        }
        interface IMove {
            void OrderMovement(Vector3Int cubic_coordinates);
            void SetPathfinderDestination(Vector3Int cubic_coordinates);
        }
        /// <summary>
        /// 
        /// </summary>
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