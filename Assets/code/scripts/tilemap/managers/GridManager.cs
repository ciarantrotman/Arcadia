using System.Collections.Generic;
using code.scripts.input;
using code.scripts.tilemap.utilities;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;
using static code.scripts.tilemap.utilities.HexagonUtilities;

namespace code.scripts.tilemap.managers {
    public class GridManager : MonoBehaviour {
        private static GridManager instance { get; set; }
        
        [Title("World Grid Manager", "To be used for getting information tilemap data")]
        [SerializeField] private Grid grid;
        [SerializeField] private Tilemap obstacles;
        
        public static Grid hexagonal_grid => instance.grid;
        private void Awake() => instance = this;
        
        public static Vector3Int hovered_cell => hexagonal_grid.WorldToCell(CursorManager.world_position());
        public static Vector3 cell_size => instance.grid.cellSize;
        public static Vector3Int get_cell_coordinates(Vector3 world_position) => hexagonal_grid.WorldToCell(world_position);
        public static Vector3 get_world_position(Vector3Int offset_coordinate) => hexagonal_grid.CellToWorld(offset_coordinate);

        public static List<CubicCoordinates> valid_coordinates_in_range(CubicCoordinates center_coordinates, int range) {
            List<CubicCoordinates> valid_coordinates_in_range = new List<CubicCoordinates>();
            IEnumerable<CubicCoordinates> all_coordinates_in_range = coordinates_within_range(center_coordinates, range);
            foreach (CubicCoordinates cubic_coordinate in all_coordinates_in_range) {
                if (instance.obstacles.GetTile(cubic_coordinate.cubic_to_offset())) {
                    Visualise.Hexagon(cubic_coordinate.cubic_to_offset(), Color.red);
                }
                else {
                    valid_coordinates_in_range.Add(cubic_coordinate);
                    Visualise.Hexagon(cubic_coordinate.cubic_to_offset(), Color.green);
                }
            }
            return valid_coordinates_in_range;
        }
    }
}