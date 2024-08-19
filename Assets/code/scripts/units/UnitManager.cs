using System;
using System.Collections.Generic;
using code.scripts.input;
using code.scripts.tilemap.managers;
using code.scripts.tilemap.utilities;
using UnityEngine;

namespace code.scripts.units {
    public class UnitManager : MonoBehaviour {
        //private PlayerControls controls;
        public static UnitManager instance;
        
        public List<Unit> allUnits = new List<Unit>();
        public List<Unit> selectedUnits = new List<Unit>();

        private void Awake() {
            instance = this;
        }

        private void Start() {
            InputManager.instance.controls.action_map.move.performed += context => MoveSelectedUnitsToCursor();
            InputManager.instance.controls.action_map.cancel.performed += context => DeselectAllSelectedUnits();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void MoveSelectedUnitsToCursor() {
            foreach (Unit unit_to_move in instance.selectedUnits) {
                unit_to_move.OrderMovement(GridManager.hovered_cell);
                // Debug.Log($"{unit_to_move.data.information.name} was ordered to move to {GridManager.hovered_cell.offset_to_cubic().ReadableLabel()}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit_to_select"></param>
        public static void SelectUnit(Unit unit_to_select) {
            if (instance.selectedUnits.Contains(unit_to_select)) {
                Debug.LogWarning($"{unit_to_select.data.information.name} is already selected");
            } else {
                instance.selectedUnits.Add(unit_to_select); 
                Debug.Log($"{unit_to_select.data.information.name} was selected");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private static void DeselectAllSelectedUnits() {
            List<Unit> cached_selected_units = new List<Unit>(instance.selectedUnits);
            foreach (Unit unit_to_deselect in cached_selected_units) {
                unit_to_deselect.Deselect();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit_to_deselect"></param>
        public static void DeselectUnit(Unit unit_to_deselect) {
            if (instance.selectedUnits.Contains(unit_to_deselect)) {
                Debug.Log($"Trying to deselect {unit_to_deselect.data.information.name}");
                instance.selectedUnits.Remove(unit_to_deselect); 
                Debug.Log($"{unit_to_deselect.data.information.name} was deselected");
            } else {
                Debug.LogError($"Cannot deselect {unit_to_deselect.data.information.name} as it is not selected");
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit_to_register"></param>
        public static void RegisterUnit(Unit unit_to_register) {
            if (instance == null) return;
            if (instance.allUnits.Contains(unit_to_register)) {
                Debug.LogError($"{unit_to_register.data.information.name} is already registered with UnitManager");
            } else {
               instance.allUnits.Add(unit_to_register); 
               Debug.Log($"{unit_to_register.data.information.name} was registered with UnitManager");
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
                Debug.Log($"{unit_to_deregister.data.information.name} was deregistered from UnitManager");
            } else {
                Debug.LogError($"Cannot deregister {unit_to_deregister.data.information.name} as it is not registered with UnitManager");
            }
        }
        
        //private void OnEnable() => controls.action_map.Enable();
        //private void OnDisable() => controls.action_map.Disable();
    }
}