using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace code.scripts.animation {
    public class PlayerInputDrivenAnimationController : MonoBehaviour
    {
        private PlayerControls controls;
        private Vector2 movement_direction;
        private Vector2 look_direction;
        
        private static readonly int XValue = Animator.StringToHash("x_value");
        private static readonly int YValue = Animator.StringToHash("y_value");
        
        [SerializeField] private Animator body;
        [SerializeField] private Animator head;
        
        private void Awake() {
            // controls = new PlayerControls();
            // controls.simple_player_movement.horizontal_movement.performed += ctx => movement_direction = ctx.ReadValue<Vector2>();
            // controls.simple_player_movement.rotation.performed += ctx => look_direction = ctx.ReadValue<Vector2>();
        }

        private void Update() {
            // head.SetFloat(XValue, look_direction.x);
            // head.SetFloat(YValue, look_direction.y);
            
            // body.SetFloat(XValue, movement_direction.x);
            // body.SetFloat(YValue, movement_direction.y);

            // Debug.Log($"({movement_direction.x}, {movement_direction.y}) ({body.GetFloat(XValue)}, {body.GetFloat(YValue)}");
        }
    }
}
