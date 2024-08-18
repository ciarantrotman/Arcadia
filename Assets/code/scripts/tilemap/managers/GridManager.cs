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
        private void Awake() => instance = this;
        
        public static Vector3Int hovered_cell => hexagonal_grid.WorldToCell(CursorManager.world_position());
        public static Vector3 cell_size => instance.grid.cellSize;
        public static Vector3Int GetCellCoordinate(Vector3 world_position) => hexagonal_grid.WorldToCell(world_position);
        public static Vector3 GetWorldPosition(Vector3Int offset_coordinate) => hexagonal_grid.CellToWorld(offset_coordinate);
    }
}