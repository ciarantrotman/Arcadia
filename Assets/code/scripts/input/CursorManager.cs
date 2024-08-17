using code.scripts.camera;
using UnityEngine;

namespace code.scripts.input {
    public class CursorManager : MonoBehaviour {
        public static CursorManager instance { get; private set; }
        private void Awake() => instance = this;

        public static Vector2 screen_position() => Input.mousePosition;
        public static Vector2 world_position() => CameraManager.main_camera().ScreenToWorldPoint(screen_position());
    }
}
