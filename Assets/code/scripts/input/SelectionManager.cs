using code.scripts.interfaces;
using UnityEngine;

namespace code.scripts.input {
    public class SelectionManager : MonoBehaviour {
        
        private static void Select() {
            if (!CursorManager.cursor_raycast(out RaycastHit2D hit)) return;
            Interfaces.ISelect entity = hit.collider.GetComponent<Interfaces.ISelect>();
            entity?.Select();
            // PlayInspectAudio();
        }
        
    }
}