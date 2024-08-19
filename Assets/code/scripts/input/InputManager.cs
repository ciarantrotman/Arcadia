using System.Linq;
using UnityEngine;
using static code.scripts.interfaces.Interfaces;

namespace code.scripts.input {
    public class InputManager : MonoBehaviour {
        public static InputManager instance;
        protected internal PlayerControls controls;
        
        private void Awake() {
            instance = this;
            controls = new PlayerControls();
            controls.action_map.select.performed += context => Select();
            controls.action_map.inspect.performed += context => Inspect();
            controls.action_map.cancel.performed += context => DeselectAllSelectedEntities();
        }
        
        private void OnEnable() => controls.action_map.Enable();
        private void OnDisable() => controls.action_map.Disable();
        /// <summary>
        /// 
        /// </summary>
        private static void Select() {
            if (!CursorManager.cursor_raycast(out RaycastHit2D hit)) return;
            ISelect entity = hit.collider.GetComponent<ISelect>();
            entity?.Select();
        }
        /// <summary>
        /// 
        /// </summary>
        private static void DeselectAllSelectedEntities() {
            ISelect[] selectables = FindObjectsOfType<MonoBehaviour>().OfType<ISelect>().ToArray();
            foreach (ISelect selectable in selectables.Where(select => select.selected)) {
                selectable.Deselect();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private static void Inspect() {
            if (!CursorManager.cursor_raycast(out RaycastHit2D hit)) return;
            IInspect entity = hit.collider.GetComponent<IInspect>();
            entity?.Inspect();
        }
    }
}