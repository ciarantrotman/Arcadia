using System;
using System.Collections.Generic;
using code.scripts.tilemap.managers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace code.scripts.tilemap.utilities {
    public static class HexagonUtilities {
        /// <summary>
        /// Cubic Coordinates for a point-top Hexagonal Grid 
        /// </summary>
        [Serializable] public struct CubicCoordinates {
            [HideLabel, HorizontalGroup, ReadOnly] public readonly int q;
            [HideLabel, HorizontalGroup, ReadOnly] public readonly int r;
            [HideLabel, HorizontalGroup, ReadOnly] public readonly int s;
            /// <summary>
            /// Cubic Coordinates for a point-top Hexagonal Grid 
            /// </summary>
            /// <param name="q"></param>
            /// <param name="r"></param>
            /// <param name="s"></param>
            public CubicCoordinates(int q, int r, int s) {
                this.q = q;
                this.r = r;
                this.s = s;
            }
        }
        public static string readable_label(this CubicCoordinates a) => $"({a.q}, {a.r}, {a.s})";
        /// <summary>
        /// Converts provided Cubic Coordinates into the Offset Coordinate system used by Unity
        /// </summary>
        /// <param name="cubic">Cubic Coordinates</param>
        /// <returns>Offset Coordinates</returns>
        public static Vector3Int cubic_to_offset(this CubicCoordinates cubic) {
            int q = cubic.q + (cubic.r - (cubic.r & 1)) / 2;
            int r = cubic.r;
            return new Vector3Int(q, r);
        }
        /// <summary>
        /// Converts provided Offset Coordinates into the Cubic Coordinate system required for grid functions
        /// </summary>
        /// <param name="offset">Offset Coordinates</param>
        /// <returns>Cubic Coordinates</returns>
        public static CubicCoordinates offset_to_cubic(this Vector3Int offset) {
            int q = offset.x - (offset.y - (offset.y & 1)) / 2;
            int r = offset.y;
            int s = -q - r;
            return new CubicCoordinates(q, r, s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fractional_cubic_coordinates"></param>
        /// <returns></returns>
        private static CubicCoordinates round_to_cubic_coordinates(Vector3 fractional_cubic_coordinates) {
            float q = Mathf.Round(fractional_cubic_coordinates.x);
            float r = Mathf.Round(fractional_cubic_coordinates.y);
            float s = Mathf.Round(fractional_cubic_coordinates.z);
            
            float q_difference = Mathf.Abs(q - fractional_cubic_coordinates.x);
            float r_difference = Mathf.Abs(r - fractional_cubic_coordinates.y);
            float s_difference = Mathf.Abs(s - fractional_cubic_coordinates.z);

            if (q_difference > r_difference && q_difference > s_difference) {
                q = -r - s;
            } else if (r_difference > s_difference) {
                r = -q - s;
            } else {
                s = -q - r;
            }
            
            return new CubicCoordinates((int)q, (int)r, (int)s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static CubicCoordinates add_cubic_coordinates(CubicCoordinates a, CubicCoordinates b) => new(a.q + b.q, a.r + b.r, a.s + b.s);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static CubicCoordinates subtract_cubic_coordinates(CubicCoordinates a, CubicCoordinates b) => new(a.q - b.q, a.r - b.r, a.s - b.s);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        private static CubicCoordinates multiply_cubic_coordinate(CubicCoordinates a, int factor) => new(a.q * factor, a.r * factor, a.s * factor);

        public static int distance_between_cubic_coordinates(CubicCoordinates a, CubicCoordinates b) {
            CubicCoordinates vector = subtract_cubic_coordinates(a, b);
            return (int)((Math.Abs(vector.q) + Math.Abs(vector.r) + Math.Abs(vector.s)) * .5f);
        }

        public static readonly CubicCoordinates[] CubicNeighbourVectors = {
            new CubicCoordinates(+1, 0, -1), new CubicCoordinates(+1, -1, 0), new CubicCoordinates(0, -1, +1),
            new CubicCoordinates(-1, 0, +1), new CubicCoordinates(-1, +1, 0), new CubicCoordinates(0, +1, -1)
        };
        
        public static readonly CubicCoordinates[] CubicDiagonalVectors = {
            new CubicCoordinates(+2, -1, -1), new CubicCoordinates(+1, -2, +1), new CubicCoordinates(-1, -1, +2),
            new CubicCoordinates(-2, +1, +1), new CubicCoordinates(-1, +2, -1), new CubicCoordinates(+1, +1, -2)
        };
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private static CubicCoordinates neighbour_vector(int direction) => CubicNeighbourVectors[direction];
        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private static CubicCoordinates diagonal_vector(int direction) => CubicNeighbourVectors[direction];
        public enum NeighbourDirection {
            NorthEast, East, SouthEast,
            SouthWest, West, NorthWest
        }
        public enum DiagonalDirection {
            North, NorthEast, SouthEast,
            South, SouthWest, NorthWest
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="neighbour_direction"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static CubicCoordinates neighbour_vector(NeighbourDirection neighbour_direction) {
            return neighbour_direction switch {
                NeighbourDirection.NorthEast => neighbour_vector(direction: 5),
                NeighbourDirection.East =>      neighbour_vector(direction: 0),
                NeighbourDirection.SouthEast => neighbour_vector(direction: 1),
                NeighbourDirection.SouthWest => neighbour_vector(direction: 2),
                NeighbourDirection.West =>      neighbour_vector(direction: 3),
                NeighbourDirection.NorthWest => neighbour_vector(direction: 4),
                _ => throw new ArgumentOutOfRangeException(nameof(neighbour_direction), neighbour_direction, null)
            };
        }
        private static CubicCoordinates diagonal_vector(DiagonalDirection diagonal_direction) {
            return diagonal_direction switch {
                DiagonalDirection.North =>     diagonal_vector(direction: 5),
                DiagonalDirection.NorthEast => diagonal_vector(direction: 0),
                DiagonalDirection.SouthEast => diagonal_vector(direction: 1),
                DiagonalDirection.South =>     diagonal_vector(direction: 2),
                DiagonalDirection.SouthWest => diagonal_vector(direction: 3),
                DiagonalDirection.NorthWest => diagonal_vector(direction: 4),
                _ => throw new ArgumentOutOfRangeException(nameof(diagonal_direction), diagonal_direction, null)
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static CubicCoordinates neighbour_cubic_coordinate(this CubicCoordinates hex, int direction) => add_cubic_coordinates(hex, neighbour_vector(direction));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="neighbour_direction"></param>
        /// <returns></returns>
        public static CubicCoordinates neighbour_cubic_coordinate(this CubicCoordinates hex, NeighbourDirection neighbour_direction) => add_cubic_coordinates(hex, neighbour_vector(neighbour_direction));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static CubicCoordinates diagonal_cubic_coordinate(this CubicCoordinates hex, int direction) => add_cubic_coordinates(hex, diagonal_vector(direction));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="diagonal_direction"></param>
        /// <returns></returns>
        public static CubicCoordinates diagonal_cubic_coordinate(this CubicCoordinates hex, DiagonalDirection diagonal_direction) => add_cubic_coordinates(hex, diagonal_vector(diagonal_direction));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private static Vector3 unrounded_lerp_cubic_coordinates(CubicCoordinates a, CubicCoordinates b, float t) {
            return new Vector3(
                Mathf.Lerp(a.q, b.q, t),
                Mathf.Lerp(a.r, b.r, t),
                Mathf.Lerp(a.s, b.s, t));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static IEnumerable<CubicCoordinates> line_between_cubic_coordinates(CubicCoordinates a, CubicCoordinates b) {
            int distance = distance_between_cubic_coordinates(a, b);
            List<CubicCoordinates> line_segment_coordinates = new List<CubicCoordinates>();
            for (int i = 0; i <= distance; i++) {
                line_segment_coordinates.Add(round_to_cubic_coordinates(unrounded_lerp_cubic_coordinates(a, b, 1f / distance * i)));
            }
            return line_segment_coordinates;
        }
        /// <summary>
        /// Returns a list of cubic coordinates for every cell within the defined range of the defined cell
        /// </summary>
        /// <param name="center_coordinates"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static IEnumerable<CubicCoordinates> coordinates_within_range(CubicCoordinates center_coordinates, int range) {
            List<CubicCoordinates> coordinates_in_range = new List<CubicCoordinates>();
            for (int q = -range; q <= range; q++) {
                for (int r = -range; r <= range; r++) {
                    for (int s = -range; s <= range; s++) {
                        if (q + r + s == 0) {
                            coordinates_in_range.Add(add_cubic_coordinates(center_coordinates, new CubicCoordinates(q, r, s)));
                        }
                    }
                }
            }
            return coordinates_in_range;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public static Vector3Int get_offset_coordinates(this Transform transform) => GridManager.hexagonal_grid.WorldToCell(transform.position);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public static CubicCoordinates get_cubic_coordinates(this Transform transform) => transform.get_offset_coordinates().offset_to_cubic();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public static bool is_equal_to(this CubicCoordinates coordinates, CubicCoordinates comparison) {
            bool q = coordinates.q == comparison.q;
            bool r = coordinates.r == comparison.r;
            bool s = coordinates.s == comparison.s;
            return q && r && s;
        }
    }
}