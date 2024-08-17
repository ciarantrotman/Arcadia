using code.scripts.interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace code.scripts.input {
    public class SelectionManager : MonoBehaviour {
        public static SelectionManager instance;
        private PlayerControls controls;

        [HideInInspector] public UnityEvent selection;
        [HideInInspector] public UnityEvent null_selection;
        
        private void Awake() {
            instance = this;
            controls = new PlayerControls();
            controls.action_map.select.performed += context => Select();
        }
        
        private void OnEnable() => controls.action_map.Enable();
        private void OnDisable() => controls.action_map.Disable();

        private static void Select() {
            instance.selection.Invoke();
            if (!CursorManager.cursor_raycast(out RaycastHit2D hit)) return;
            Interfaces.ISelect entity = hit.collider.GetComponent<Interfaces.ISelect>();
            if (entity == null) {
                instance.null_selection.Invoke();
            } else {
                entity.Select();
            }
        }
    }
}