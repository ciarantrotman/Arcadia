using code.scripts.outline;
using Sirenix.OdinInspector;
using UnityEngine;
using static code.scripts.interfaces.Interfaces;

namespace code.scripts.objects {
    public abstract class Object : MonoBehaviour, IInteract, IInspect {
        [InlineEditor(InlineEditorModes.GUIAndPreview), SerializeField] private ObjectData data;
        
        private OutlinedObject outline;

        private void Awake() => outline = GetComponent<OutlinedObject>();

        public void Inspect() => Debug.Log($"<b>{name}</b>: {data.information.name} has been inspected → <i>{data.information.description}</i>");
        public void TriggerInteraction() {
            Debug.Log($"<b>{name}</b>: {data.information.name} Triggered Interaction");
            // outline.SetOutlineOverrideState(true);
            OnTriggerInteraction();
        }
        protected abstract void OnTriggerInteraction();
        public void FinishInteraction() {
            Debug.Log($"<b>{name}</b>: {data.information.name} Finished Interaction");
            // outline.SetOutlineOverrideState(false);
            OnFinishInteraction();
        }
        protected abstract void OnFinishInteraction();
    }
}