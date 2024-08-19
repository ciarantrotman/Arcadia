using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using code.scripts.tilemap.managers;
using code.scripts.units;
using UnityEngine;

namespace code.behaviours {
	public class MoveToCubicCoordinates : Action {
		public Unit unit;
		public SharedVector3Int coordinates;
		
		public override void OnStart() {
			unit.pathfinder.destination = GridManager.GetWorldPosition(coordinates.Value);
			unit.pathfinder.SearchPath();
			Debug.Log("unit-movement-started");
		}

		public override TaskStatus OnUpdate() {
			Debug.Log($"unit-movement-updated → {finished_movement()}");
			return finished_movement()
				? TaskStatus.Success 
				: TaskStatus.Running;
		}

		private bool finished_movement() => unit.pathfinder.reachedDestination;// || unit.pathfinder.reachedEndOfPath;
	}
}