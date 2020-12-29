// GENERATED AUTOMATICALLY FROM 'Assets/MasterInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MasterInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MasterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MasterInput"",
    ""maps"": [
        {
            ""name"": ""BallThrow"",
            ""id"": ""22fb90e6-65d3-4290-80e2-7983e45ca6a9"",
            ""actions"": [
                {
                    ""name"": ""StartThrow"",
                    ""type"": ""Button"",
                    ""id"": ""d4350bcc-b6a1-4749-a01f-d17d6264e5d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StopThrow"",
                    ""type"": ""Button"",
                    ""id"": ""06613eb9-7bea-453a-8e78-8e3891ca7737"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ThrowPosition"",
                    ""type"": ""Value"",
                    ""id"": ""218a2bdc-321c-44b0-a90d-155f32a023f6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""097b82a2-ba4d-45cf-b42e-da5273e39187"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""KeybaordMouse"",
                    ""action"": ""StartThrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""410bedf7-caba-4a95-856f-fb0f1fbf1e09"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""KeybaordMouse"",
                    ""action"": ""StopThrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f91b2ace-5e9c-4237-985a-930273b41e92"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeybaordMouse"",
                    ""action"": ""ThrowPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Spawn"",
            ""id"": ""2d9b717b-4e05-4c66-a6d3-1302bf4f103e"",
            ""actions"": [
                {
                    ""name"": ""SpawnBall"",
                    ""type"": ""Button"",
                    ""id"": ""7368c70e-913a-4b06-8d24-2364b1fb15bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e9abb1f3-b43f-436a-916c-ce2f45c09ca6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""KeybaordMouse"",
                    ""action"": ""SpawnBall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeybaordMouse"",
            ""bindingGroup"": ""KeybaordMouse"",
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
        // BallThrow
        m_BallThrow = asset.FindActionMap("BallThrow", throwIfNotFound: true);
        m_BallThrow_StartThrow = m_BallThrow.FindAction("StartThrow", throwIfNotFound: true);
        m_BallThrow_StopThrow = m_BallThrow.FindAction("StopThrow", throwIfNotFound: true);
        m_BallThrow_ThrowPosition = m_BallThrow.FindAction("ThrowPosition", throwIfNotFound: true);
        // Spawn
        m_Spawn = asset.FindActionMap("Spawn", throwIfNotFound: true);
        m_Spawn_SpawnBall = m_Spawn.FindAction("SpawnBall", throwIfNotFound: true);
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

    // BallThrow
    private readonly InputActionMap m_BallThrow;
    private IBallThrowActions m_BallThrowActionsCallbackInterface;
    private readonly InputAction m_BallThrow_StartThrow;
    private readonly InputAction m_BallThrow_StopThrow;
    private readonly InputAction m_BallThrow_ThrowPosition;
    public struct BallThrowActions
    {
        private @MasterInput m_Wrapper;
        public BallThrowActions(@MasterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @StartThrow => m_Wrapper.m_BallThrow_StartThrow;
        public InputAction @StopThrow => m_Wrapper.m_BallThrow_StopThrow;
        public InputAction @ThrowPosition => m_Wrapper.m_BallThrow_ThrowPosition;
        public InputActionMap Get() { return m_Wrapper.m_BallThrow; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BallThrowActions set) { return set.Get(); }
        public void SetCallbacks(IBallThrowActions instance)
        {
            if (m_Wrapper.m_BallThrowActionsCallbackInterface != null)
            {
                @StartThrow.started -= m_Wrapper.m_BallThrowActionsCallbackInterface.OnStartThrow;
                @StartThrow.performed -= m_Wrapper.m_BallThrowActionsCallbackInterface.OnStartThrow;
                @StartThrow.canceled -= m_Wrapper.m_BallThrowActionsCallbackInterface.OnStartThrow;
                @StopThrow.started -= m_Wrapper.m_BallThrowActionsCallbackInterface.OnStopThrow;
                @StopThrow.performed -= m_Wrapper.m_BallThrowActionsCallbackInterface.OnStopThrow;
                @StopThrow.canceled -= m_Wrapper.m_BallThrowActionsCallbackInterface.OnStopThrow;
                @ThrowPosition.started -= m_Wrapper.m_BallThrowActionsCallbackInterface.OnThrowPosition;
                @ThrowPosition.performed -= m_Wrapper.m_BallThrowActionsCallbackInterface.OnThrowPosition;
                @ThrowPosition.canceled -= m_Wrapper.m_BallThrowActionsCallbackInterface.OnThrowPosition;
            }
            m_Wrapper.m_BallThrowActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StartThrow.started += instance.OnStartThrow;
                @StartThrow.performed += instance.OnStartThrow;
                @StartThrow.canceled += instance.OnStartThrow;
                @StopThrow.started += instance.OnStopThrow;
                @StopThrow.performed += instance.OnStopThrow;
                @StopThrow.canceled += instance.OnStopThrow;
                @ThrowPosition.started += instance.OnThrowPosition;
                @ThrowPosition.performed += instance.OnThrowPosition;
                @ThrowPosition.canceled += instance.OnThrowPosition;
            }
        }
    }
    public BallThrowActions @BallThrow => new BallThrowActions(this);

    // Spawn
    private readonly InputActionMap m_Spawn;
    private ISpawnActions m_SpawnActionsCallbackInterface;
    private readonly InputAction m_Spawn_SpawnBall;
    public struct SpawnActions
    {
        private @MasterInput m_Wrapper;
        public SpawnActions(@MasterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @SpawnBall => m_Wrapper.m_Spawn_SpawnBall;
        public InputActionMap Get() { return m_Wrapper.m_Spawn; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpawnActions set) { return set.Get(); }
        public void SetCallbacks(ISpawnActions instance)
        {
            if (m_Wrapper.m_SpawnActionsCallbackInterface != null)
            {
                @SpawnBall.started -= m_Wrapper.m_SpawnActionsCallbackInterface.OnSpawnBall;
                @SpawnBall.performed -= m_Wrapper.m_SpawnActionsCallbackInterface.OnSpawnBall;
                @SpawnBall.canceled -= m_Wrapper.m_SpawnActionsCallbackInterface.OnSpawnBall;
            }
            m_Wrapper.m_SpawnActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SpawnBall.started += instance.OnSpawnBall;
                @SpawnBall.performed += instance.OnSpawnBall;
                @SpawnBall.canceled += instance.OnSpawnBall;
            }
        }
    }
    public SpawnActions @Spawn => new SpawnActions(this);
    private int m_KeybaordMouseSchemeIndex = -1;
    public InputControlScheme KeybaordMouseScheme
    {
        get
        {
            if (m_KeybaordMouseSchemeIndex == -1) m_KeybaordMouseSchemeIndex = asset.FindControlSchemeIndex("KeybaordMouse");
            return asset.controlSchemes[m_KeybaordMouseSchemeIndex];
        }
    }
    public interface IBallThrowActions
    {
        void OnStartThrow(InputAction.CallbackContext context);
        void OnStopThrow(InputAction.CallbackContext context);
        void OnThrowPosition(InputAction.CallbackContext context);
    }
    public interface ISpawnActions
    {
        void OnSpawnBall(InputAction.CallbackContext context);
    }
}
