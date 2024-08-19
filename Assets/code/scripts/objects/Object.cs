using System;
using code.scripts.outline;
using Sirenix.OdinInspector;
using UnityEngine;
using static code.scripts.interfaces.Interfaces;

namespace code.scripts.objects {
    public abstract class Object : MonoBehaviour, ISelect, IInspect {
        [InlineEditor(InlineEditorModes.GUIAndPreview), SerializeField] private ObjectData data;
        private OutlinedObject outline;
        private void Awake() {
            outline = GetComponent<OutlinedObject>();
        }

        public bool selected { get; set; }

        public void Select() {
            selected = true;
            outline.SetOutlineOverrideState(true);
            OnSelected();
        }
        /// <summary>
        /// 
        /// </summary>
        protected abstract void OnSelected();
        public void Deselect() {
            selected = false;
            outline.SetOutlineOverrideState(false);
            OnDeselected();
        }
        /// <summary>
        /// 
        /// </summary>
        protected abstract void OnDeselected();
        
        public void Inspect() => Debug.Log($"<b>{name}</b>: {data.information.name} has been inspected → <i>{data.information.description}</i>");
    }
}