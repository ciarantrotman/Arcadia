using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using code.scripts.tilemap.managers;
using code.scripts.tilemap.utilities;
using code.scripts.units;
using UnityEngine;

namespace code.behaviours {
	public class OrderMoveToCoordinates : Action {
		public Unit unit;
		public override TaskStatus OnUpdate() {
			return finished_movement()
				? TaskStatus.Success 
				: TaskStatus.Running;
		}
		private bool finished_movement() => unit.pathfinder.reachedDestination;
	}
}