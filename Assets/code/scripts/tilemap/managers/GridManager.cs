using code.scripts.input;
using code.scripts.tilemap.utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace code.scripts.tilemap.managers {
    public class GridManager : MonoBehaviour {
        private static GridManager instance { get; set; }
        
        [Title("World Grid Manager", "To be used for getting information tilemap data")]
        [SerializeField] private Grid grid;
        
        public static Grid hexagonal_grid => instance.grid;
        public static Vector3Int hovered_cell => hexagonal_grid.WorldToCell(CursorManager.world_position());
        
        private void Awake() => instance = this;
    }
}