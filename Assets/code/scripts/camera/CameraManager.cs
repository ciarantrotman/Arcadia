using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace code.scripts.camera {
    public class CameraManager : MonoBehaviour {
        [SerializeField, BoxGroup("Static Camera References")] private new Camera camera;
        [SerializeField, BoxGroup("Static Camera References")] private PixelPerfectCamera pixelPerfectCamera;

        private static CameraManager instance { get; set; }
        private void Awake() => instance = this;

        public static Camera main_camera() => instance.camera;
        public static PixelPerfectCamera pixel_perfect_camera() => instance.pixelPerfectCamera;
    }
}
