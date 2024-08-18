//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/controls/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""action_map"",
            ""id"": ""d0ba44ad-bb56-45ba-9dd4-74129f771f45"",
            ""actions"": [
                {
                    ""name"": ""planar_movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5b99cfc7-ed50-4843-9197-b0f4b4e8af81"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""select"",
                    ""type"": ""Button"",
                    ""id"": ""1b0f9356-cb86-4b1f-b07c-00ceb446136e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""inspect"",
                    ""type"": ""Button"",
                    ""id"": ""06931cb2-c29c-4fc9-bee0-59402f107902"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""move"",
                    ""type"": ""Button"",
                    ""id"": ""ded8dacb-0576-4b33-8993-b177e1a7175d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""010732d0-bb89-4703-87d3-acec05cf1b66"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""planar_movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c3eaeb7c-3ccc-49f4-8d07-7259c52cabc4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard-and-mouse-scheme"",
                    ""action"": ""planar_movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a03bd082-aef9-41ba-bf13-8721ba4bc8fd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard-and-mouse-scheme"",
                    ""action"": ""planar_movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""78054225-0867-484b-82b4-46e6ca695adf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard-and-mouse-scheme"",
                    ""action"": ""planar_movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6dbe77a6-ef76-4756-9731-a5dc3f1518f2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard-and-mouse-scheme"",
                    ""action"": ""planar_movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6cd23283-5dbd-482a-aa4f-1641ac1db1b4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""planar_movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e245a401-8cf0-4018-9614-ccb972cf9102"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard-and-mouse-scheme"",
                    ""action"": ""planar_movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0cd3f493-d877-4488-9898-6891a9833395"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard-and-mouse-scheme"",
                    ""action"": ""planar_movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""361b57a3-faef-4226-afb4-bb41899c294c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard-and-mouse-scheme"",
                    ""action"": ""planar_movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cb8719d7-3752-49e7-9687-2ab4152e5d2f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard-and-mouse-scheme"",
                    ""action"": ""planar_movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""92cf5ff8-b39d-453f-b2e3-afb44d8c766d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard-and-mouse-scheme"",
                    ""action"": ""select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44aba078-2aea-4371-a790-c8eb8d9fbd11"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard-and-mouse-scheme"",
                    ""action"": ""select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""970af2f6-984d-4b24-80d2-ae38f278644b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard-and-mouse-scheme"",
                    ""action"": ""inspect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1874c31d-846c-4025-a9cd-78bdf00971cd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard-and-mouse-scheme"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e35e947c-b463-4935-ae8b-ad036237177e"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard-and-mouse-scheme"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""keyboard-and-mouse-scheme"",
            ""bindingGroup"": ""keyboard-and-mouse-scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // action_map
        m_action_map = asset.FindActionMap("action_map", throwIfNotFound: true);
        m_action_map_planar_movement = m_action_map.FindAction("planar_movement", throwIfNotFound: true);
        m_action_map_select = m_action_map.FindAction("select", throwIfNotFound: true);
        m_action_map_inspect = m_action_map.FindAction("inspect", throwIfNotFound: true);
        m_action_map_move = m_action_map.FindAction("move", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // action_map
    private readonly InputActionMap m_action_map;
    private List<IAction_mapActions> m_Action_mapActionsCallbackInterfaces = new List<IAction_mapActions>();
    private readonly InputAction m_action_map_planar_movement;
    private readonly InputAction m_action_map_select;
    private readonly InputAction m_action_map_inspect;
    private readonly InputAction m_action_map_move;
    public struct Action_mapActions
    {
        private @PlayerControls m_Wrapper;
        public Action_mapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @planar_movement => m_Wrapper.m_action_map_planar_movement;
        public InputAction @select => m_Wrapper.m_action_map_select;
        public InputAction @inspect => m_Wrapper.m_action_map_inspect;
        public InputAction @move => m_Wrapper.m_action_map_move;
        public InputActionMap Get() { return m_Wrapper.m_action_map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Action_mapActions set) { return set.Get(); }
        public void AddCallbacks(IAction_mapActions instance)
        {
            if (instance == null || m_Wrapper.m_Action_mapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Action_mapActionsCallbackInterfaces.Add(instance);
            @planar_movement.started += instance.OnPlanar_movement;
            @planar_movement.performed += instance.OnPlanar_movement;
            @planar_movement.canceled += instance.OnPlanar_movement;
            @select.started += instance.OnSelect;
            @select.performed += instance.OnSelect;
            @select.canceled += instance.OnSelect;
            @inspect.started += instance.OnInspect;
            @inspect.performed += instance.OnInspect;
            @inspect.canceled += instance.OnInspect;
            @move.started += instance.OnMove;
            @move.performed += instance.OnMove;
            @move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(IAction_mapActions instance)
        {
            @planar_movement.started -= instance.OnPlanar_movement;
            @planar_movement.performed -= instance.OnPlanar_movement;
            @planar_movement.canceled -= instance.OnPlanar_movement;
            @select.started -= instance.OnSelect;
            @select.performed -= instance.OnSelect;
            @select.canceled -= instance.OnSelect;
            @inspect.started -= instance.OnInspect;
            @inspect.performed -= instance.OnInspect;
            @inspect.canceled -= instance.OnInspect;
            @move.started -= instance.OnMove;
            @move.performed -= instance.OnMove;
            @move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(IAction_mapActions instance)
        {
            if (m_Wrapper.m_Action_mapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAction_mapActions instance)
        {
            foreach (var item in m_Wrapper.m_Action_mapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Action_mapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Action_mapActions @action_map => new Action_mapActions(this);
    private int m_keyboardandmouseschemeSchemeIndex = -1;
    public InputControlScheme keyboardandmouseschemeScheme
    {
        get
        {
            if (m_keyboardandmouseschemeSchemeIndex == -1) m_keyboardandmouseschemeSchemeIndex = asset.FindControlSchemeIndex("keyboard-and-mouse-scheme");
            return asset.controlSchemes[m_keyboardandmouseschemeSchemeIndex];
        }
    }
    public interface IAction_mapActions
    {
        void OnPlanar_movement(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnInspect(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
