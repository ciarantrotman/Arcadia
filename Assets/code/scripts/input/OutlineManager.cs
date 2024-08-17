using System.Collections.Generic;
using System.Linq;
using code.scripts.interfaces;
using UnityEngine;
using static code.scripts.interfaces.Interfaces;

namespace code.scripts.input {
    public class OutlineManager : MonoBehaviour {
        public static OutlineManager instance;
        [SerializeField] internal Material material;
        
        private List<Interfaces.IOutline> all_outlines = new List<Interfaces.IOutline>();
        
        private void Awake() => instance = this;

        private void Update() {
            ManageOutlineState();
            SyncActiveOutlines();
        }
        
        private static void Select() {
            if (!CursorRaycastHit(out RaycastHit2D hit)) return;
            Interfaces.ISelect entity = hit.collider.GetComponent<Interfaces.ISelect>();
            entity?.Select();
            // PlayInspectAudio();
        }
        
        public void RegisterOutline(Interfaces.IOutline target) {
            all_outlines.Add(target);
            target.InitialiseOutline();
        }

        private void ManageOutlineState() {
            // todo - add concept of pausing
            // if (InterfaceManger.GameIsPaused() || dialogue) return;
            foreach (IOutline outline in all_outlines.Where(outline => outline.subject.enabled)) {
                outline.SetOutlineState(false);
            }
            if (!CursorRaycastHit(out RaycastHit2D hit)) return;
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

        private static RaycastHit2D CursorRaycastHit(out RaycastHit2D hit) {
            hit = Physics2D.Raycast(CursorManager.world_position(), Vector2.zero, 0f);
            return hit;
        }
    }
}