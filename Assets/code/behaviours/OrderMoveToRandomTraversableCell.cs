using System.Linq;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using code.scripts.tilemap.managers;
using code.scripts.tilemap.utilities;
using code.scripts.units;
using UnityEngine;

namespace code.behaviours {
    public class OrderMoveToRandomTraversableCell : Action {
        public Unit unit;
        
        public override void OnStart() {
            int random_index = Random.Range(0, unit.traversable_cells_in_range.Count());
            unit.OrderMovement(unit.traversable_cells_in_range[random_index].cubic_to_offset());
        }

        public override TaskStatus OnUpdate() {
            return TaskStatus.Success;
        }
    }
}