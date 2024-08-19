using System;
using code.scripts.outline;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace code.scripts.units {
    [CreateAssetMenu(fileName = "new-unit-data", menuName = "Unit/Data", order = 0)]
    public class UnitData : ScriptableObject {
        [Serializable] public struct Information {
            public string name;
        }
        [Serializable] public struct VisionProperties {
            [Range(1, 16)] public int range;
        }
        [Title("Unit Data", "Information and generic class behaviours for this unit type")]
        public Information information;
        public VisionProperties vision;
        public Outline outline;
    }
}