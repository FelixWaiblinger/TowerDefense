//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/Input/GameInput.inputactions
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

public partial class @GameInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""GameControls"",
            ""id"": ""bdfdad2b-afd4-4f8a-a1c1-a1f0a03a1960"",
            ""actions"": [
                {
                    ""name"": ""BuildMenu"",
                    ""type"": ""Button"",
                    ""id"": ""cd278fca-46cb-4781-b41d-54922d105b2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EndDay"",
                    ""type"": ""Button"",
                    ""id"": ""25984f56-390c-42d8-8bb8-5d9bb74bd431"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""49d175b4-168d-4df6-a01f-82c9b2d1ba42"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""861c3f80-84b4-4342-8473-63851831dff0"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""BuildMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17263a1d-2034-4e09-b983-94176722a147"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""EndDay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c6e5531-92ed-42ce-afbb-e2eef92b5dd4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MouseKeyboard"",
            ""bindingGroup"": ""MouseKeyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // GameControls
        m_GameControls = asset.FindActionMap("GameControls", throwIfNotFound: true);
        m_GameControls_BuildMenu = m_GameControls.FindAction("BuildMenu", throwIfNotFound: true);
        m_GameControls_EndDay = m_GameControls.FindAction("EndDay", throwIfNotFound: true);
        m_GameControls_Move = m_GameControls.FindAction("Move", throwIfNotFound: true);
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

    // GameControls
    private readonly InputActionMap m_GameControls;
    private List<IGameControlsActions> m_GameControlsActionsCallbackInterfaces = new List<IGameControlsActions>();
    private readonly InputAction m_GameControls_BuildMenu;
    private readonly InputAction m_GameControls_EndDay;
    private readonly InputAction m_GameControls_Move;
    public struct GameControlsActions
    {
        private @GameInput m_Wrapper;
        public GameControlsActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @BuildMenu => m_Wrapper.m_GameControls_BuildMenu;
        public InputAction @EndDay => m_Wrapper.m_GameControls_EndDay;
        public InputAction @Move => m_Wrapper.m_GameControls_Move;
        public InputActionMap Get() { return m_Wrapper.m_GameControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameControlsActions set) { return set.Get(); }
        public void AddCallbacks(IGameControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_GameControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameControlsActionsCallbackInterfaces.Add(instance);
            @BuildMenu.started += instance.OnBuildMenu;
            @BuildMenu.performed += instance.OnBuildMenu;
            @BuildMenu.canceled += instance.OnBuildMenu;
            @EndDay.started += instance.OnEndDay;
            @EndDay.performed += instance.OnEndDay;
            @EndDay.canceled += instance.OnEndDay;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(IGameControlsActions instance)
        {
            @BuildMenu.started -= instance.OnBuildMenu;
            @BuildMenu.performed -= instance.OnBuildMenu;
            @BuildMenu.canceled -= instance.OnBuildMenu;
            @EndDay.started -= instance.OnEndDay;
            @EndDay.performed -= instance.OnEndDay;
            @EndDay.canceled -= instance.OnEndDay;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(IGameControlsActions instance)
        {
            if (m_Wrapper.m_GameControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_GameControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameControlsActions @GameControls => new GameControlsActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("MouseKeyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    public interface IGameControlsActions
    {
        void OnBuildMenu(InputAction.CallbackContext context);
        void OnEndDay(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}