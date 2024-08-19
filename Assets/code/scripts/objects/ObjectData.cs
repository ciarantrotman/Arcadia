using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace code.scripts.objects {
    [CreateAssetMenu(fileName = "new-object-data", menuName = "Object/Data", order = 0)]
    public class ObjectData : ScriptableObject {
        [Serializable] public struct ObjectInformation {
            [Title("Object Information")]
            public string name;
            [TextArea] public string description;
        }
        public ObjectInformation information;
    }
}