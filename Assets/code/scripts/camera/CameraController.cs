using code.scripts.input;
using UnityEngine;

namespace code.scripts.camera {
    public class CameraController : MonoBehaviour {
        [SerializeField, Range(.05f, 3f)] private float speed = 1f;
        
        private Vector2 camera_translation;
        private void Start() => InputManager.instance.controls.action_map.planar_movement.performed += context => camera_translation = context.ReadValue<Vector2>();
        private void Update() => ApplyCameraTranslation();

        private void ApplyCameraTranslation() {
            Vector3 framerate_independent_translation = (new Vector3(camera_translation.x, camera_translation.y) * Time.deltaTime);
            transform.Translate(framerate_independent_translation * speed, Space.World);
        }
    }
}
