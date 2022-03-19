// GENERATED AUTOMATICALLY FROM 'Assets/Scenes/Testing/New Folder/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player Movment"",
            ""id"": ""a290ec75-bcde-4be6-8b30-ac3ee245543a"",
            ""actions"": [
                {
                    ""name"": ""Movment"",
                    ""type"": ""PassThrough"",
                    ""id"": ""243229b5-326e-48a8-9fc8-50f7163f0c41"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Button"",
                    ""id"": ""7e4b48c3-775d-4ad1-83ae-180272fcbab0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0408d92e-b1e2-4c9a-b87b-acb411ce5632"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d3b7d3e4-9f9b-460b-bad7-1f96291c5984"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9cae54ea-2c91-4ce0-be34-35062e85af29"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""849b4a9c-5702-468b-82a2-2570f037ffcf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e898a358-b73f-4c09-b5a3-836b01788b1a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0f4ad536-09b3-4718-8db5-fe524dcaedef"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6cdbca9-dced-4172-8b78-bb265db0565e"",
                    ""path"": ""<Mouse>/Delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movment
        m_PlayerMovment = asset.FindActionMap("Player Movment", throwIfNotFound: true);
        m_PlayerMovment_Movment = m_PlayerMovment.FindAction("Movment", throwIfNotFound: true);
        m_PlayerMovment_Camera = m_PlayerMovment.FindAction("Camera", throwIfNotFound: true);
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

    // Player Movment
    private readonly InputActionMap m_PlayerMovment;
    private IPlayerMovmentActions m_PlayerMovmentActionsCallbackInterface;
    private readonly InputAction m_PlayerMovment_Movment;
    private readonly InputAction m_PlayerMovment_Camera;
    public struct PlayerMovmentActions
    {
        private @Controls m_Wrapper;
        public PlayerMovmentActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movment => m_Wrapper.m_PlayerMovment_Movment;
        public InputAction @Camera => m_Wrapper.m_PlayerMovment_Camera;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovment; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovmentActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovmentActions instance)
        {
            if (m_Wrapper.m_PlayerMovmentActionsCallbackInterface != null)
            {
                @Movment.started -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnMovment;
                @Movment.performed -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnMovment;
                @Movment.canceled -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnMovment;
                @Camera.started -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerMovmentActionsCallbackInterface.OnCamera;
            }
            m_Wrapper.m_PlayerMovmentActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movment.started += instance.OnMovment;
                @Movment.performed += instance.OnMovment;
                @Movment.canceled += instance.OnMovment;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
            }
        }
    }
    public PlayerMovmentActions @PlayerMovment => new PlayerMovmentActions(this);
    public interface IPlayerMovmentActions
    {
        void OnMovment(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
}
