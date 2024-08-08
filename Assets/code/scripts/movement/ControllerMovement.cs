using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace code.scripts.movement {
    public class ControllerMovement : MonoBehaviour {
        private PlayerControls controls;

        public float multiplier = 1f; 
        public float rotationModifier = 100f; 
        
        private Vector2 translation;
        private Vector2 rotation;

        private void Awake() {
            controls = new PlayerControls();
            
            controls.simple_player_movement.horizontal_movement.performed += ctx => translation = ctx.ReadValue<Vector2>();
            controls.simple_player_movement.horizontal_movement.canceled += ctx => translation = Vector2.zero;
            
            controls.simple_player_movement.rotation.performed += ctx => rotation = ctx.ReadValue<Vector2>();
            controls.simple_player_movement.rotation.canceled += ctx => rotation = Vector2.zero;
        }

        private void Update() {
            ApplyTranslation();
            ApplyRotation();
        }

        private void ApplyTranslation() {
            Vector3 framerate_independent_translation = (new Vector3(translation.x, 0, translation.y) * Time.deltaTime);
            transform.Translate(framerate_independent_translation * multiplier, Space.Self);
        }

        private void ApplyRotation() {
            Vector3 framerate_independent_rotation = (new Vector3(-rotation.y, rotation.x, 0) * Time.deltaTime);
            transform.Rotate(framerate_independent_rotation * rotationModifier, Space.Self);
            Vector3 current_rotation = transform.eulerAngles;
            transform.eulerAngles = new Vector3(current_rotation.x, current_rotation.y, 0);
        }

        private void OnEnable() {
            controls.simple_player_movement.Enable();
        }
        
        private void OnDisable() {
            controls.simple_player_movement.Disable();
        }
    }
}
