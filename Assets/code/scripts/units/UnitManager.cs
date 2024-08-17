using System.Collections.Generic;
using UnityEngine;

namespace code.scripts.units {
    public class UnitManager : MonoBehaviour {
        public static UnitManager instance;
        
        public List<Unit> allUnits = new List<Unit>();
        public List<Unit> selectedUnits = new List<Unit>();

        private void Awake() {
            instance = this;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit_to_select"></param>
        public static void SelectUnit(Unit unit_to_select) {
            if (instance.selectedUnits.Contains(unit_to_select)) {
                Debug.LogError($"{unit_to_select.data.unitName} is already selected");
            } else {
                instance.selectedUnits.Add(unit_to_select); 
                Debug.Log($"{unit_to_select.data.unitName} was selected");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit_to_deselect"></param>
        public static void DeselectUnit(Unit unit_to_deselect) {
            if (instance.selectedUnits.Contains(unit_to_deselect)) {
                instance.selectedUnits.Remove(unit_to_deselect); 
                Debug.Log($"{unit_to_deselect.data.unitName} was deselected");
            } else {
                Debug.LogError($"Cannot deselect {unit_to_deselect.data.unitName} as it is not selected");
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit_to_register"></param>
        public static void RegisterUnit(Unit unit_to_register) {
            if (instance == null) return;
            if (instance.allUnits.Contains(unit_to_register)) {
                Debug.LogError($"{unit_to_register.data.unitName} is already registered");
            } else {
               instance.allUnits.Add(unit_to_register); 
               Debug.Log($"{unit_to_register.data.unitName} was registered with UnitManager");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit_to_deregister"></param>
        public static void DeregisterUnit(Unit unit_to_deregister) {
            if (instance == null) return;
            if (instance.allUnits.Contains(unit_to_deregister)) {
                instance.allUnits.Remove(unit_to_deregister); 
                Debug.Log($"{unit_to_deregister.data.unitName} was deregistered from UnitManager");
            } else {
                Debug.LogError($"Cannot deregister {unit_to_deregister.data.unitName} as it is not registered with UnitManager");
            }
        }
    }
}