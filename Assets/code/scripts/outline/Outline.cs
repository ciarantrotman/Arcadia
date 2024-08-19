using UnityEngine;

namespace code.scripts.outline {
    [CreateAssetMenu(fileName = "new-outline", menuName = "Outline", order = 0)]
    public class Outline : ScriptableObject {
        public Color color;
    }
}