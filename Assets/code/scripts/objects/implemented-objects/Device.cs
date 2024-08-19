using code.scripts.tilemap.utilities;
using code.scripts.units;
using UnityEngine;

namespace code.scripts.objects.implemented_objects {
    public class Device : Object {
        protected override void OnTriggerInteraction() {
            Debug.Log("Trigger");
            foreach (Unit unit in UnitManager.instance.selected_units) {
                Debug.Log(unit.name);
                unit.OrderMovement(transform.offset_coordinates());
            }
        }

        private void start_device_interaction() {
            
        }

        protected override void OnFinishInteraction() {

        }
    }
}