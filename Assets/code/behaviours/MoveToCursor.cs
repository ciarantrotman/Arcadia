using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using code.scripts.tilemap.managers;
using code.scripts.units;

namespace code.behaviours {
	public class MoveToCursor : Action
	{
		public Unit unit;
		public SharedVector3Int cell;
		public override TaskStatus OnUpdate() {
			unit.pathfinder.destination = GridManager.GetWorldPosition(cell.Value);
			return unit.pathfinder.reachedDestination || unit.pathfinder.reachedEndOfPath 
				? TaskStatus.Success 
				: TaskStatus.Running;
		}
	}
}