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
            controls.action_map.interact.performed += context => Interact();
            controls.action_map.inspect.performed += context => Inspect();
            controls.action_map.cancel.performed += context => DeselectAllSelectedEntities();
        }
        
        private void OnEnable() => controls.action_map.Enable();
        private void OnDisable() => controls.action_map.Disable();
        /// <summary>
        /// Selects whatever object the cursor is currently hovering over
        /// </summary>
        private static void Select() {
            // if we select nothing, take that as wanting to clear our selected items
            if (!CursorManager.cursor_raycast(out RaycastHit2D hit)) {
                DeselectAllSelectedEntities();
                return;
            }
            ISelect entity = hit.collider.GetComponent<ISelect>();
            if (entity == null) return;
            // allow us to deselect when selecting an already selected object
            if (entity.selected) {
                entity.Deselect();
                return;
            }
            // if the object has exclusive selection, deselect everything else first
            if (entity.exclusive_selection) {
                DeselectAllSelectedEntities();
            }
            entity.Select();
        }
        /// <summary>
        /// Finds all selected objects in the scene and deselects them
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
        /// <summary>
        /// 
        /// </summary>
        private static void Interact() {
            if (!CursorManager.cursor_raycast(out RaycastHit2D hit)) return;
            IInteract entity = hit.collider.GetComponent<IInteract>();
            entity?.TriggerInteraction();
        }
    }
}