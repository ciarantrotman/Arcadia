using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace code.scripts.movement {
    public class ControllerMovement : MonoBehaviour {
        private PlayerControls controls;

        [SerializeField, Range(0f, 1f)] private float multiplier = 1f;

        private static readonly float[] IsometricAngles = { 60, 120, -120, -60, 0, 90, -90, 180 };
        
        private Vector2 translation;
        private Vector2 rotation;

        private Vector2 snapped_translation;
        private Vector2 snapped_rotation;

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
            
            VisualiseRawInput();
        }

        private void ApplyTranslation() {
            snapped_translation = snap_to_isometric_angles(translation);
            
            Vector3 framerate_independent_translation = (new Vector3(snapped_translation.x, snapped_translation.y) * Time.deltaTime);
            transform.Translate(framerate_independent_translation * multiplier, Space.Self);
        }

        private void ApplyRotation() {
            snapped_rotation = snap_to_isometric_angles(rotation);
        }
        
        private static Vector2 snap_to_isometric_angles(Vector2 vector) {
            if (vector == Vector2.zero) return Vector2.zero;

            // Calculate the angle of the input vector
            float angle = Vector2.SignedAngle(Vector2.up, vector);

            // Find the closest isometric angle
            float min_difference = float.MaxValue;
            float snapped_angle = 0;

            foreach (float iso_angle in IsometricAngles)
            {
                float difference = Mathf.Abs(angle - iso_angle);
                if (difference < min_difference)
                {
                    min_difference = difference;
                    snapped_angle = iso_angle;
                }
            }
            
            Vector2 snapped_vector = Quaternion.Euler(0, 0, snapped_angle) * Vector2.up;
            return snapped_vector;
        }

        private void VisualiseRawInput() {
            Vector3 position = transform.position;
            Debug.DrawRay(position, translation, Color.blue);
            Debug.DrawRay(position, snapped_translation, Color.blue);
            
            
            Debug.DrawRay(position, rotation, Color.red);
            Debug.DrawRay(position, snapped_rotation, Color.red);
        }
        
        private void OnEnable() {
            controls.simple_player_movement.Enable();
        }
        
        private void OnDisable() {
            controls.simple_player_movement.Disable();
        }
    }
}
