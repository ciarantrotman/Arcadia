using System.Collections.Generic;
using code.scripts.tilemap.managers;
using static code.scripts.tilemap.utilities.HexagonUtilities;
using UnityEngine;

namespace code.scripts.tilemap.utilities {
    public static class Visualise {
        private static readonly Grid Grid = GridManager.hexagonal_grid;
        
        private static readonly float HalfCellWidth = Grid.cellSize.x * .5f;
        private static readonly float HalfCellHeight = Grid.cellSize.y * .5f;
        private static readonly float QuarterCellHeight = Grid.cellSize.y * .25f;
        
        private static readonly Vector3[] HexagonLocalPoints = {
            new Vector3(0, HalfCellHeight), new Vector3(HalfCellWidth, QuarterCellHeight), new Vector3(HalfCellWidth, -QuarterCellHeight),
            new Vector3(0, -HalfCellHeight), new Vector3(-HalfCellWidth, -QuarterCellHeight), new Vector3(-HalfCellWidth, QuarterCellHeight)
        };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cell_offset_coordinate"></param>
        /// <param name="color"></param>
        public static void Hexagon(Vector3Int cell_offset_coordinate, Color color) {
            Vector3 cell_world_position = Grid.GetCellCenterWorld(cell_offset_coordinate);
            for (int i = 0; i < HexagonLocalPoints.Length; i++) {
                Debug.DrawLine(
                    Grid.LocalToWorld(cell_world_position + HexagonLocalPoints[i]), 
                    Grid.LocalToWorld(cell_world_position + HexagonLocalPoints[(i + 1) % HexagonLocalPoints.Length]),
                    color);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cell_offset_coordinate"></param>
        /// <param name="color"></param>
        public static void NeighbourHexagons(Vector3Int cell_offset_coordinate, Color color) {
            for (int i = 0; i < CubicNeighbourVectors.Length; i++) {
                Hexagon(cell_offset_coordinate.offset_to_cubic().neighbour_cubic_coordinate(i).cubic_to_offset(), color);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cell_offset_coordinate"></param>
        /// <param name="range"></param>
        /// <param name="color"></param>
        public static void HexagonsInRange(Vector3Int cell_offset_coordinate, int range, Color color) {
            foreach (CubicCoordinates cubic_coordinates in coordinates_within_range(cell_offset_coordinate.offset_to_cubic(), range)) {
                Hexagon(cubic_coordinates.cubic_to_offset(), color);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="color"></param>
        public static void Line(Vector3Int a, Vector3Int b, Color color) {
            IEnumerable<CubicCoordinates> segments = line_between_cubic_coordinates(a.offset_to_cubic(), b.offset_to_cubic());
            foreach (CubicCoordinates cubic_coordinates in segments) {
                Hexagon(cubic_coordinates.cubic_to_offset(), color);
            }
        }
    }
}