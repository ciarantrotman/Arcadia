using UnityEngine;
using UnityEngine.Serialization;

namespace code.scripts.units {
    [CreateAssetMenu(fileName = "new-unit-data", menuName = "Unit/Data", order = 0)]
    public class UnitData : ScriptableObject {
        public string unitName;
        [TextArea] public string description;

        public Color debugColor;
    }
}