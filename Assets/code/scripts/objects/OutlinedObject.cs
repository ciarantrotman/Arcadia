using System;
using code.scripts.input;
using code.scripts.interfaces;
using UnityEngine;

namespace code.scripts.objects {
    [RequireComponent(typeof(SpriteRenderer))]
    public class OutlinedObject : MonoBehaviour, Interfaces.IOutline {
        [SerializeField] private Outline outline;
        private SpriteRenderer target;
        private SpriteRenderer subject;
        private bool outline_state_override;

        private void Awake() => target = GetComponent<SpriteRenderer>();

        private void Start() => OutlineManager.RegisterOutline(this);
        
        private void OnEnable() => OutlineManager.RegisterOutline(this);
        private void OnDisable() => OutlineManager.DeregisterOutline(this);

        SpriteRenderer Interfaces.IOutline.target {
            get => target;
            set => target = value;
        }

        SpriteRenderer Interfaces.IOutline.subject {
            get => subject;
            set => subject = value;
        }

        bool Interfaces.IOutline.outline_state_override {
            get => outline_state_override;
            set => outline_state_override = value;
        }

        public void InitialiseOutline() {
            GameObject outline_object = new ($"{name}-outline") {
                transform = {
                    parent = target.transform, 
                    localPosition = Vector3.zero,
                    localScale = Vector3.one
                }
            };
            subject = outline_object.AddComponent<SpriteRenderer>();
            subject.material = OutlineManager.instance.material;
            subject.sortingOrder = target.sortingOrder - 1;
            subject.color = outline.color;
            subject.enabled = false;
        }

        public void SetOutlineState(bool state) => subject.enabled = state || outline_state_override;
        public void SetOutlineOverrideState(bool state) => outline_state_override = state;
    }
}