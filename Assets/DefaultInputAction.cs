//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/DefaultInputAction.inputactions
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

public partial class @DefaultInputAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @DefaultInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefaultInputAction"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""5dd9e545-161e-4b59-83c9-ac760c650fd7"",
            ""actions"": [
                {
                    ""name"": ""True"",
                    ""type"": ""Button"",
                    ""id"": ""a61eccf2-a6da-4853-a065-046268ed13de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""False"",
                    ""type"": ""Button"",
                    ""id"": ""06d02a21-9098-4164-9f05-cd8f478463e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Skip"",
                    ""type"": ""Button"",
                    ""id"": ""96a87e48-dd6c-4cf7-b0a8-da3d0525b06a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d096a03e-e655-4a79-97d2-31173fbcc353"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""True"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8dd8082-2073-44ee-80da-0af45627a72d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""False"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8da136fd-bfeb-44d6-b6f1-408d0477ab34"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Skip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
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
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_True = m_Gameplay.FindAction("True", throwIfNotFound: true);
        m_Gameplay_False = m_Gameplay.FindAction("False", throwIfNotFound: true);
        m_Gameplay_Skip = m_Gameplay.FindAction("Skip", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_True;
    private readonly InputAction m_Gameplay_False;
    private readonly InputAction m_Gameplay_Skip;
    public struct GameplayActions
    {
        private @DefaultInputAction m_Wrapper;
        public GameplayActions(@DefaultInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @True => m_Wrapper.m_Gameplay_True;
        public InputAction @False => m_Wrapper.m_Gameplay_False;
        public InputAction @Skip => m_Wrapper.m_Gameplay_Skip;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @True.started += instance.OnTrue;
            @True.performed += instance.OnTrue;
            @True.canceled += instance.OnTrue;
            @False.started += instance.OnFalse;
            @False.performed += instance.OnFalse;
            @False.canceled += instance.OnFalse;
            @Skip.started += instance.OnSkip;
            @Skip.performed += instance.OnSkip;
            @Skip.canceled += instance.OnSkip;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @True.started -= instance.OnTrue;
            @True.performed -= instance.OnTrue;
            @True.canceled -= instance.OnTrue;
            @False.started -= instance.OnFalse;
            @False.performed -= instance.OnFalse;
            @False.canceled -= instance.OnFalse;
            @Skip.started -= instance.OnSkip;
            @Skip.performed -= instance.OnSkip;
            @Skip.canceled -= instance.OnSkip;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnTrue(InputAction.CallbackContext context);
        void OnFalse(InputAction.CallbackContext context);
        void OnSkip(InputAction.CallbackContext context);
    }
}
