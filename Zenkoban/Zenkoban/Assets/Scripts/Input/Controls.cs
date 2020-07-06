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
    public struct InGameActions
    {
        private @Controls m_Wrapper;
        public InGameActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveUp => m_Wrapper.m_InGame_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_InGame_MoveDown;
        public InputAction @MoveLeft => m_Wrapper.m_InGame_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_InGame_MoveRight;
        public InputAction @Undo => m_Wrapper.m_InGame_Undo;
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
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);
    public interface IInGameActions
    {
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnUndo(InputAction.CallbackContext context);
    }
}
