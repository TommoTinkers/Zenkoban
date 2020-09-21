// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/Controls.inputactions'

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
            ""name"": ""InGame"",
            ""id"": ""7ef59f27-e8fe-4ccc-95a1-da6af83379c6"",
            ""actions"": [
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""ecfddadf-9eeb-4b19-9148-acb7f535180a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""db536ccc-303c-45f3-970e-2ab92b4a1ebc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""66075ef4-bdf6-4f94-b0b3-20432301f242"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""8d6a5abb-f151-4e79-aa8d-c98f04315f48"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Undo"",
                    ""type"": ""Button"",
                    ""id"": ""80e2725f-cf4a-4c7b-885d-2c96419340a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""219f3a15-8551-43a2-9ce6-392c213eb63f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""120d986a-046e-45f9-a4d7-65811b499244"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03c9eaf1-ec07-4742-9b06-b28a5dded87b"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb775299-2e98-4d73-9222-21b4fa56e155"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""268e095f-e5a0-46ee-b113-91e160ec3499"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2686f7a1-170f-4976-9b26-9afa09c036da"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4460292f-c530-4412-aab4-2dddecc9a055"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f64cdb0-21e1-427a-9421-4ebadeff5587"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7c8cc37-7399-45d6-8038-208d5d9580b6"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6dc0d4d-a12d-4d1f-b644-a7a59bd13a99"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Undo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7beef8b-1985-4cee-9b2f-f6078066d98d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Undo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1bea465-a294-4873-b698-3d4bc27b1d2f"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d4d2f4b-b19d-4066-9a29-c333065f2d2e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Carousel"",
            ""id"": ""7f024c6b-7822-46bc-a680-4de523ff69d9"",
            ""actions"": [
                {
                    ""name"": ""CycleLeft"",
                    ""type"": ""Button"",
                    ""id"": ""d9d8092b-e5d4-4bea-9c7c-0ec44593a038"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleRight"",
                    ""type"": ""Button"",
                    ""id"": ""2bcf6159-33bb-4133-a10c-53e26dc8c79f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""fbbb9707-70e0-400a-8b39-47ee1d0a1e7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""71707eb0-91bb-4fd1-9fd3-29d404f101e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""16262a64-b725-4227-86c6-07720fac3eb2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d44a43ba-db00-455e-a3d1-3e1dae6fa640"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""544348e4-e022-45a7-b86c-1cc79292505c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca709d7a-5b71-44b5-9bbe-d63655823f13"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39eae3c0-8e9c-4c06-b503-3812a2f7dc16"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12d34be0-aa88-4682-8087-8114fd0c6df7"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e8e496c-978c-4835-85cc-b66185877705"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""LinearMenu"",
            ""id"": ""ce60a70b-b0b7-4c64-891c-546354cab456"",
            ""actions"": [
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""890bfc1e-7491-4756-a11c-1fe7d109d465"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""07f3e824-e038-41cb-b48e-f895c0150979"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""471db267-6d76-4642-bfbd-66479bfb4819"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""647265aa-80ff-472f-aea0-e447e1450aa2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40dd651a-81d8-46d8-afa1-bce52b8af8e0"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a2045fa-b9dc-476f-aa90-3d49896d741b"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cabee40-b5b6-4a1f-98f4-2282300f548a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a22a9293-46b9-4f2c-9453-b49f59a5fae7"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0cd9d381-af97-49c0-a938-ccd0ef16b7c0"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""EndOfLevel"",
            ""id"": ""bb010f24-7d49-4e38-a902-b505e1a89fdd"",
            ""actions"": [
                {
                    ""name"": ""Continue"",
                    ""type"": ""Button"",
                    ""id"": ""7d793c2e-50b5-4d9a-a527-e5140c5c6707"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Replay"",
                    ""type"": ""Button"",
                    ""id"": ""27843854-2e3f-498b-bde8-dff2ed19d056"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Home"",
                    ""type"": ""Button"",
                    ""id"": ""de55ab33-0724-4dee-933e-7a62214f3cd6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a139fd35-3516-4896-a471-9d939149e3f4"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Continue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc78485f-af38-4ca9-b157-56e2a13d7a8f"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Replay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf425f2d-a84b-45bc-a714-0ff86d5231ba"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Home"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InGame
        m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
        m_InGame_MoveUp = m_InGame.FindAction("MoveUp", throwIfNotFound: true);
        m_InGame_MoveDown = m_InGame.FindAction("MoveDown", throwIfNotFound: true);
        m_InGame_MoveLeft = m_InGame.FindAction("MoveLeft", throwIfNotFound: true);
        m_InGame_MoveRight = m_InGame.FindAction("MoveRight", throwIfNotFound: true);
        m_InGame_Undo = m_InGame.FindAction("Undo", throwIfNotFound: true);
        m_InGame_Menu = m_InGame.FindAction("Menu", throwIfNotFound: true);
        // Carousel
        m_Carousel = asset.FindActionMap("Carousel", throwIfNotFound: true);
        m_Carousel_CycleLeft = m_Carousel.FindAction("CycleLeft", throwIfNotFound: true);
        m_Carousel_CycleRight = m_Carousel.FindAction("CycleRight", throwIfNotFound: true);
        m_Carousel_Select = m_Carousel.FindAction("Select", throwIfNotFound: true);
        m_Carousel_Back = m_Carousel.FindAction("Back", throwIfNotFound: true);
        // LinearMenu
        m_LinearMenu = asset.FindActionMap("LinearMenu", throwIfNotFound: true);
        m_LinearMenu_Down = m_LinearMenu.FindAction("Down", throwIfNotFound: true);
        m_LinearMenu_Up = m_LinearMenu.FindAction("Up", throwIfNotFound: true);
        m_LinearMenu_Select = m_LinearMenu.FindAction("Select", throwIfNotFound: true);
        // EndOfLevel
        m_EndOfLevel = asset.FindActionMap("EndOfLevel", throwIfNotFound: true);
        m_EndOfLevel_Continue = m_EndOfLevel.FindAction("Continue", throwIfNotFound: true);
        m_EndOfLevel_Replay = m_EndOfLevel.FindAction("Replay", throwIfNotFound: true);
        m_EndOfLevel_Home = m_EndOfLevel.FindAction("Home", throwIfNotFound: true);
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

    // InGame
    private readonly InputActionMap m_InGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_InGame_MoveUp;
    private readonly InputAction m_InGame_MoveDown;
    private readonly InputAction m_InGame_MoveLeft;
    private readonly InputAction m_InGame_MoveRight;
    private readonly InputAction m_InGame_Undo;
    private readonly InputAction m_InGame_Menu;
    public struct InGameActions
    {
        private @Controls m_Wrapper;
        public InGameActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveUp => m_Wrapper.m_InGame_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_InGame_MoveDown;
        public InputAction @MoveLeft => m_Wrapper.m_InGame_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_InGame_MoveRight;
        public InputAction @Undo => m_Wrapper.m_InGame_Undo;
        public InputAction @Menu => m_Wrapper.m_InGame_Menu;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                @MoveUp.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMoveUp;
                @MoveUp.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMoveUp;
                @MoveUp.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMoveUp;
                @MoveDown.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMoveDown;
                @MoveDown.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMoveDown;
                @MoveDown.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMoveDown;
                @MoveLeft.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMoveRight;
                @Undo.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnUndo;
                @Undo.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnUndo;
                @Undo.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnUndo;
                @Menu.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMenu;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveUp.started += instance.OnMoveUp;
                @MoveUp.performed += instance.OnMoveUp;
                @MoveUp.canceled += instance.OnMoveUp;
                @MoveDown.started += instance.OnMoveDown;
                @MoveDown.performed += instance.OnMoveDown;
                @MoveDown.canceled += instance.OnMoveDown;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @Undo.started += instance.OnUndo;
                @Undo.performed += instance.OnUndo;
                @Undo.canceled += instance.OnUndo;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);

    // Carousel
    private readonly InputActionMap m_Carousel;
    private ICarouselActions m_CarouselActionsCallbackInterface;
    private readonly InputAction m_Carousel_CycleLeft;
    private readonly InputAction m_Carousel_CycleRight;
    private readonly InputAction m_Carousel_Select;
    private readonly InputAction m_Carousel_Back;
    public struct CarouselActions
    {
        private @Controls m_Wrapper;
        public CarouselActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @CycleLeft => m_Wrapper.m_Carousel_CycleLeft;
        public InputAction @CycleRight => m_Wrapper.m_Carousel_CycleRight;
        public InputAction @Select => m_Wrapper.m_Carousel_Select;
        public InputAction @Back => m_Wrapper.m_Carousel_Back;
        public InputActionMap Get() { return m_Wrapper.m_Carousel; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarouselActions set) { return set.Get(); }
        public void SetCallbacks(ICarouselActions instance)
        {
            if (m_Wrapper.m_CarouselActionsCallbackInterface != null)
            {
                @CycleLeft.started -= m_Wrapper.m_CarouselActionsCallbackInterface.OnCycleLeft;
                @CycleLeft.performed -= m_Wrapper.m_CarouselActionsCallbackInterface.OnCycleLeft;
                @CycleLeft.canceled -= m_Wrapper.m_CarouselActionsCallbackInterface.OnCycleLeft;
                @CycleRight.started -= m_Wrapper.m_CarouselActionsCallbackInterface.OnCycleRight;
                @CycleRight.performed -= m_Wrapper.m_CarouselActionsCallbackInterface.OnCycleRight;
                @CycleRight.canceled -= m_Wrapper.m_CarouselActionsCallbackInterface.OnCycleRight;
                @Select.started -= m_Wrapper.m_CarouselActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_CarouselActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_CarouselActionsCallbackInterface.OnSelect;
                @Back.started -= m_Wrapper.m_CarouselActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_CarouselActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_CarouselActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_CarouselActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CycleLeft.started += instance.OnCycleLeft;
                @CycleLeft.performed += instance.OnCycleLeft;
                @CycleLeft.canceled += instance.OnCycleLeft;
                @CycleRight.started += instance.OnCycleRight;
                @CycleRight.performed += instance.OnCycleRight;
                @CycleRight.canceled += instance.OnCycleRight;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public CarouselActions @Carousel => new CarouselActions(this);

    // LinearMenu
    private readonly InputActionMap m_LinearMenu;
    private ILinearMenuActions m_LinearMenuActionsCallbackInterface;
    private readonly InputAction m_LinearMenu_Down;
    private readonly InputAction m_LinearMenu_Up;
    private readonly InputAction m_LinearMenu_Select;
    public struct LinearMenuActions
    {
        private @Controls m_Wrapper;
        public LinearMenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Down => m_Wrapper.m_LinearMenu_Down;
        public InputAction @Up => m_Wrapper.m_LinearMenu_Up;
        public InputAction @Select => m_Wrapper.m_LinearMenu_Select;
        public InputActionMap Get() { return m_Wrapper.m_LinearMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LinearMenuActions set) { return set.Get(); }
        public void SetCallbacks(ILinearMenuActions instance)
        {
            if (m_Wrapper.m_LinearMenuActionsCallbackInterface != null)
            {
                @Down.started -= m_Wrapper.m_LinearMenuActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_LinearMenuActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_LinearMenuActionsCallbackInterface.OnDown;
                @Up.started -= m_Wrapper.m_LinearMenuActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_LinearMenuActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_LinearMenuActionsCallbackInterface.OnUp;
                @Select.started -= m_Wrapper.m_LinearMenuActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_LinearMenuActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_LinearMenuActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_LinearMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public LinearMenuActions @LinearMenu => new LinearMenuActions(this);

    // EndOfLevel
    private readonly InputActionMap m_EndOfLevel;
    private IEndOfLevelActions m_EndOfLevelActionsCallbackInterface;
    private readonly InputAction m_EndOfLevel_Continue;
    private readonly InputAction m_EndOfLevel_Replay;
    private readonly InputAction m_EndOfLevel_Home;
    public struct EndOfLevelActions
    {
        private @Controls m_Wrapper;
        public EndOfLevelActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Continue => m_Wrapper.m_EndOfLevel_Continue;
        public InputAction @Replay => m_Wrapper.m_EndOfLevel_Replay;
        public InputAction @Home => m_Wrapper.m_EndOfLevel_Home;
        public InputActionMap Get() { return m_Wrapper.m_EndOfLevel; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EndOfLevelActions set) { return set.Get(); }
        public void SetCallbacks(IEndOfLevelActions instance)
        {
            if (m_Wrapper.m_EndOfLevelActionsCallbackInterface != null)
            {
                @Continue.started -= m_Wrapper.m_EndOfLevelActionsCallbackInterface.OnContinue;
                @Continue.performed -= m_Wrapper.m_EndOfLevelActionsCallbackInterface.OnContinue;
                @Continue.canceled -= m_Wrapper.m_EndOfLevelActionsCallbackInterface.OnContinue;
                @Replay.started -= m_Wrapper.m_EndOfLevelActionsCallbackInterface.OnReplay;
                @Replay.performed -= m_Wrapper.m_EndOfLevelActionsCallbackInterface.OnReplay;
                @Replay.canceled -= m_Wrapper.m_EndOfLevelActionsCallbackInterface.OnReplay;
                @Home.started -= m_Wrapper.m_EndOfLevelActionsCallbackInterface.OnHome;
                @Home.performed -= m_Wrapper.m_EndOfLevelActionsCallbackInterface.OnHome;
                @Home.canceled -= m_Wrapper.m_EndOfLevelActionsCallbackInterface.OnHome;
            }
            m_Wrapper.m_EndOfLevelActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Continue.started += instance.OnContinue;
                @Continue.performed += instance.OnContinue;
                @Continue.canceled += instance.OnContinue;
                @Replay.started += instance.OnReplay;
                @Replay.performed += instance.OnReplay;
                @Replay.canceled += instance.OnReplay;
                @Home.started += instance.OnHome;
                @Home.performed += instance.OnHome;
                @Home.canceled += instance.OnHome;
            }
        }
    }
    public EndOfLevelActions @EndOfLevel => new EndOfLevelActions(this);
    public interface IInGameActions
    {
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnUndo(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
    }
    public interface ICarouselActions
    {
        void OnCycleLeft(InputAction.CallbackContext context);
        void OnCycleRight(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
    public interface ILinearMenuActions
    {
        void OnDown(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
    public interface IEndOfLevelActions
    {
        void OnContinue(InputAction.CallbackContext context);
        void OnReplay(InputAction.CallbackContext context);
        void OnHome(InputAction.CallbackContext context);
    }
}
