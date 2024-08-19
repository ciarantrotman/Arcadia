using System.Collections.Generic;
using System.Linq;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using code.scripts.tilemap.managers;
using code.scripts.tilemap.utilities;
using code.scripts.units;
using UnityEngine;
using static code.scripts.tilemap.utilities.HexagonUtilities;

namespace code.behaviours {
	public class CursorInVisionCone : Conditional {
		public Unit unit;
		public SharedVector3Int cell;
		public override TaskStatus OnUpdate() {
			IEnumerable<CubicCoordinates> cells_in_vision_cone = coordinates_within_range(unit.transform.cubic_coordinates(), unit.data.vision.range);
			bool cursor_in_vision_cone = cells_in_vision_cone.Contains(GridManager.hovered_cell.offset_to_cubic());
			if (cursor_in_vision_cone) {
				cell.Value = GridManager.hovered_cell;
			}
			Visualise.HexagonsInRange(unit.transform.offset_coordinates(), unit.data.vision.range, 
				cursor_in_vision_cone
					? Color.green
					: Color.red);
			return cursor_in_vision_cone
				? TaskStatus.Success
				: TaskStatus.Failure;
		}
	}
}