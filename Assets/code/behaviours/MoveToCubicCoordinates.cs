using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using code.scripts.tilemap.managers;
using code.scripts.units;

namespace code.behaviours {
	public class MoveToCubicCoordinates : Action {
		public Unit unit;
		public SharedVector3Int coordinates;
		
		public override void OnStart() {
			unit.pathfinder.destination = GridManager.GetWorldPosition(coordinates.Value);
			unit.pathfinder.SearchPath();
		}

		public override TaskStatus OnUpdate() {
			return unit.pathfinder.reachedDestination || unit.pathfinder.reachedEndOfPath 
				? TaskStatus.Success 
				: TaskStatus.Running;
		}
	}
}