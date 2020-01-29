// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""bda4f05e-4b44-4179-8828-beea08a7b536"",
            ""actions"": [
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Button"",
                    ""id"": ""cb413361-f108-4b19-af25-89b837f2461c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStick"",
                    ""type"": ""Button"",
                    ""id"": ""334dfc87-fac6-464a-b852-0fcc23958495"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""3263a891-7da8-4281-865c-7c64b2706726"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Square"",
                    ""type"": ""Button"",
                    ""id"": ""b140502d-a069-492c-a97e-f014f5d289ef"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""O"",
                    ""type"": ""Button"",
                    ""id"": ""5d4d3f71-3d8d-4d54-a796-83f380d962d7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Triangle"",
                    ""type"": ""Button"",
                    ""id"": ""7db14792-ce6f-4f95-aacc-958151f49b04"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""R1"",
                    ""type"": ""Button"",
                    ""id"": ""42609493-5008-4dcc-9f35-072efbc47db6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""R2"",
                    ""type"": ""Button"",
                    ""id"": ""b1e91e78-c6e5-4771-9102-9dc7d98d9197"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""L1"",
                    ""type"": ""Button"",
                    ""id"": ""ff4d3abb-d02d-4b8e-ae23-e3417f8124b2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""L2"",
                    ""type"": ""Button"",
                    ""id"": ""c5ca2222-907d-4c7f-97e0-99685b017ac0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad"",
                    ""type"": ""Button"",
                    ""id"": ""4450424d-03e3-4eb6-a2cd-caf593705444"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""d85d7686-2758-406b-a7e4-29f2b83602ca"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""3305065d-c388-43b5-86e0-87f4b22510eb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""803362c5-5338-43ed-a336-8d9f478da81e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcb3f3ea-1b2c-4df5-a70e-0d5911ef2727"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33af8c6f-aa1c-4b86-b06f-e9548d73d6c0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4f868f9-bb41-4e4e-a84e-d930097b4aba"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Square"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c020c1ff-f4b7-44a7-a1ef-8e43e3990c52"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""O"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""851b6519-927b-459b-bfe7-34de6233758e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Triangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd0ec3ca-e56b-43e8-bcf3-728ff755def5"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""R1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3902596-b91e-427e-8e3c-5e8bc63d1d52"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""R2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4a4cfa6-01d2-4257-947b-2c24b9c61869"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""L1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac95a50d-777d-4d16-8589-dd9220876c0e"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""L2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09d6b043-8d7b-4b6b-961d-db95334917e6"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2451db5-adc6-4092-9bae-a29b568c1f69"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3eac1f01-75c4-4f02-94ba-6cf8f621b146"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_LeftStick = m_Gameplay.FindAction("LeftStick", throwIfNotFound: true);
        m_Gameplay_RightStick = m_Gameplay.FindAction("RightStick", throwIfNotFound: true);
        m_Gameplay_X = m_Gameplay.FindAction("X", throwIfNotFound: true);
        m_Gameplay_Square = m_Gameplay.FindAction("Square", throwIfNotFound: true);
        m_Gameplay_O = m_Gameplay.FindAction("O", throwIfNotFound: true);
        m_Gameplay_Triangle = m_Gameplay.FindAction("Triangle", throwIfNotFound: true);
        m_Gameplay_R1 = m_Gameplay.FindAction("R1", throwIfNotFound: true);
        m_Gameplay_R2 = m_Gameplay.FindAction("R2", throwIfNotFound: true);
        m_Gameplay_L1 = m_Gameplay.FindAction("L1", throwIfNotFound: true);
        m_Gameplay_L2 = m_Gameplay.FindAction("L2", throwIfNotFound: true);
        m_Gameplay_DPad = m_Gameplay.FindAction("D-Pad", throwIfNotFound: true);
        m_Gameplay_Start = m_Gameplay.FindAction("Start", throwIfNotFound: true);
        m_Gameplay_Select = m_Gameplay.FindAction("Select", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_LeftStick;
    private readonly InputAction m_Gameplay_RightStick;
    private readonly InputAction m_Gameplay_X;
    private readonly InputAction m_Gameplay_Square;
    private readonly InputAction m_Gameplay_O;
    private readonly InputAction m_Gameplay_Triangle;
    private readonly InputAction m_Gameplay_R1;
    private readonly InputAction m_Gameplay_R2;
    private readonly InputAction m_Gameplay_L1;
    private readonly InputAction m_Gameplay_L2;
    private readonly InputAction m_Gameplay_DPad;
    private readonly InputAction m_Gameplay_Start;
    private readonly InputAction m_Gameplay_Select;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftStick => m_Wrapper.m_Gameplay_LeftStick;
        public InputAction @RightStick => m_Wrapper.m_Gameplay_RightStick;
        public InputAction @X => m_Wrapper.m_Gameplay_X;
        public InputAction @Square => m_Wrapper.m_Gameplay_Square;
        public InputAction @O => m_Wrapper.m_Gameplay_O;
        public InputAction @Triangle => m_Wrapper.m_Gameplay_Triangle;
        public InputAction @R1 => m_Wrapper.m_Gameplay_R1;
        public InputAction @R2 => m_Wrapper.m_Gameplay_R2;
        public InputAction @L1 => m_Wrapper.m_Gameplay_L1;
        public InputAction @L2 => m_Wrapper.m_Gameplay_L2;
        public InputAction @DPad => m_Wrapper.m_Gameplay_DPad;
        public InputAction @Start => m_Wrapper.m_Gameplay_Start;
        public InputAction @Select => m_Wrapper.m_Gameplay_Select;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @LeftStick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftStick;
                @RightStick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightStick;
                @RightStick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightStick;
                @RightStick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightStick;
                @X.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnX;
                @Square.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSquare;
                @Square.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSquare;
                @Square.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSquare;
                @O.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnO;
                @O.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnO;
                @O.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnO;
                @Triangle.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTriangle;
                @Triangle.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTriangle;
                @Triangle.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTriangle;
                @R1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnR1;
                @R1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnR1;
                @R1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnR1;
                @R2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnR2;
                @R2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnR2;
                @R2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnR2;
                @L1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnL1;
                @L1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnL1;
                @L1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnL1;
                @L2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnL2;
                @L2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnL2;
                @L2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnL2;
                @DPad.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPad;
                @DPad.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPad;
                @DPad.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPad;
                @Start.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStart;
                @Select.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
                @RightStick.started += instance.OnRightStick;
                @RightStick.performed += instance.OnRightStick;
                @RightStick.canceled += instance.OnRightStick;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @Square.started += instance.OnSquare;
                @Square.performed += instance.OnSquare;
                @Square.canceled += instance.OnSquare;
                @O.started += instance.OnO;
                @O.performed += instance.OnO;
                @O.canceled += instance.OnO;
                @Triangle.started += instance.OnTriangle;
                @Triangle.performed += instance.OnTriangle;
                @Triangle.canceled += instance.OnTriangle;
                @R1.started += instance.OnR1;
                @R1.performed += instance.OnR1;
                @R1.canceled += instance.OnR1;
                @R2.started += instance.OnR2;
                @R2.performed += instance.OnR2;
                @R2.canceled += instance.OnR2;
                @L1.started += instance.OnL1;
                @L1.performed += instance.OnL1;
                @L1.canceled += instance.OnL1;
                @L2.started += instance.OnL2;
                @L2.performed += instance.OnL2;
                @L2.canceled += instance.OnL2;
                @DPad.started += instance.OnDPad;
                @DPad.performed += instance.OnDPad;
                @DPad.canceled += instance.OnDPad;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnLeftStick(InputAction.CallbackContext context);
        void OnRightStick(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnSquare(InputAction.CallbackContext context);
        void OnO(InputAction.CallbackContext context);
        void OnTriangle(InputAction.CallbackContext context);
        void OnR1(InputAction.CallbackContext context);
        void OnR2(InputAction.CallbackContext context);
        void OnL1(InputAction.CallbackContext context);
        void OnL2(InputAction.CallbackContext context);
        void OnDPad(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
