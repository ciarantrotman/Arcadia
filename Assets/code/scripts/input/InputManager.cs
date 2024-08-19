using code.scripts.interfaces;
using UnityEngine;

namespace code.scripts.input {
    public class InputManager : MonoBehaviour {
        public static InputManager instance;
        protected internal PlayerControls controls;
        
        private void Awake() {
            instance = this;
            controls = new PlayerControls();
            controls.action_map.select.performed += context => Select();
        }
        
        private void OnEnable() => controls.action_map.Enable();
        private void OnDisable() => controls.action_map.Disable();

        private static void Select() {
            if (!CursorManager.cursor_raycast(out RaycastHit2D hit)) return;
            Interfaces.ISelect entity = hit.collider.GetComponent<Interfaces.ISelect>();
            entity?.Select();
        }
    }
}