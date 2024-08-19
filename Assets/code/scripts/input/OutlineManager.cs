using System.Collections.Generic;
using System.Linq;
using code.scripts.interfaces;
using UnityEngine;
using static code.scripts.interfaces.Interfaces;

namespace code.scripts.input {
    public class OutlineManager : MonoBehaviour {
        public static OutlineManager instance;
        [SerializeField] internal Material material;
        
        private List<IOutline> all_outlines = new List<Interfaces.IOutline>();
        
        private void Awake() => instance = this;

        private void Update() {
            ManageOutlineState();
            SyncActiveOutlines();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outline_to_register"></param>
        public static void RegisterOutline(IOutline outline_to_register) {
            if (instance == null) return;
            if (instance.all_outlines.Contains(outline_to_register)) {
                Debug.LogWarning($"{outline_to_register.target.name} is already registered with OutlineManager");
            } else {
                instance.all_outlines.Add(outline_to_register);
                outline_to_register.InitialiseOutline(); 
                Debug.Log($"{outline_to_register.target.name} was registered with OutlineManager");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outline_to_deregister"></param>
        public static void DeregisterOutline(IOutline outline_to_deregister) {
            if (instance == null) return;
            if (instance.all_outlines.Contains(outline_to_deregister)) {
                instance.all_outlines.Remove(outline_to_deregister);
                Debug.Log($"{outline_to_deregister.target.name} was deregistered with OutlineManager");
            } else {
                instance.all_outlines.Add(outline_to_deregister);
                Debug.LogError($"Cannot deregister {outline_to_deregister.target.name} as it is not registered with OutlineManager");
            }
        }

        private void ManageOutlineState() {
            // todo - add concept of pausing
            // if (InterfaceManger.GameIsPaused() || dialogue) return;
            foreach (IOutline outline in all_outlines.Where(outline => outline.subject.enabled)) {
                outline.SetOutlineState(false);
            }
            if (!CursorManager.cursor_raycast(out RaycastHit2D hit)) return;
            foreach (Collider2D hit_collider in hit.collider.GetComponents<Collider2D>()) {
                IOutline i_outline = hit_collider.GetComponent<IOutline>();
                i_outline?.SetOutlineState(true);
            }
        }

        private void SyncActiveOutlines() {
            foreach (IOutline outline in all_outlines.Where(outline => outline.subject.enabled)) {
                outline.subject.sprite = outline.target.sprite;
            }
        }
    }
}