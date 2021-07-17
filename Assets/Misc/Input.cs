// GENERATED AUTOMATICALLY FROM 'Assets/Misc/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Misc
{
    public class @Input : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Input()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Build"",
            ""id"": ""e4084b2a-bab1-472f-b2de-8233c95b02e2"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""72327387-bc83-4818-8afc-df8ebf5818e5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fly"",
                    ""type"": ""Value"",
                    ""id"": ""b1cc3ffb-0b6a-409d-8f7c-260d06fada3c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Act1"",
                    ""type"": ""Button"",
                    ""id"": ""51e9e6ec-e015-455a-b7b6-808358903ebb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Act2"",
                    ""type"": ""Button"",
                    ""id"": ""c064aed5-4892-4d7e-ba65-15d28e3d565a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActPos"",
                    ""type"": ""Value"",
                    ""id"": ""304bcd00-22cb-4d97-a703-ff60a2cb1825"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""f2669751-968f-4f27-ae8d-c24b2386090d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""7e480152-c790-4b6a-99bd-9efbcee50c88"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Change"",
                    ""type"": ""Value"",
                    ""id"": ""d89dc8a0-f383-4695-8a38-0ffb41ac143b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""48e6e77a-ad95-42e4-b53d-abce067f0d26"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a0a66241-83ef-4265-a88f-cf2c98e7a70b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""299bd27f-141d-46ef-9610-b2906bf7696f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e47a7529-b2a0-443c-85f3-c30442bf3b10"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f9db8791-0c86-4610-a92f-d94dd91282ec"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""CtrlShift"",
                    ""id"": ""3a196445-ecbb-44e9-bd54-d7c223223fb7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e46d4a22-6a3f-4148-ac92-8973e470028c"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b1643ebd-43ab-42f3-8fcd-3118b4cc93ca"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""EQ"",
                    ""id"": ""14ff522a-37e4-4d90-8948-ae4210299a8c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0b6a2b85-fb0e-4cb0-bd58-f2e982541c5d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e4a384c1-3dc3-45ae-9c31-0e9430a78603"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6f7e5691-7845-45f6-9c1f-3568030706db"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Act1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53aba6c3-44fe-45df-b0ac-1fedf4feea9c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Act2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6eb4ef6-7566-4296-a269-350f7a0bcd3c"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41805a0d-bb10-4f62-b55f-62432ce952f9"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30d59366-0e34-4027-a832-971a85db2afd"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(min=-120,max=120)"",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""521e62c2-a106-448c-83a6-38a70ccca638"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a0d2dc3e-73e8-432b-83bc-c81127751ec7"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e400c82d-bfa0-4c95-93cc-daa2aa093216"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Build
            m_Build = asset.FindActionMap("Build", throwIfNotFound: true);
            m_Build_Move = m_Build.FindAction("Move", throwIfNotFound: true);
            m_Build_Fly = m_Build.FindAction("Fly", throwIfNotFound: true);
            m_Build_Act1 = m_Build.FindAction("Act1", throwIfNotFound: true);
            m_Build_Act2 = m_Build.FindAction("Act2", throwIfNotFound: true);
            m_Build_ActPos = m_Build.FindAction("ActPos", throwIfNotFound: true);
            m_Build_Look = m_Build.FindAction("Look", throwIfNotFound: true);
            m_Build_Scroll = m_Build.FindAction("Scroll", throwIfNotFound: true);
            m_Build_Change = m_Build.FindAction("Change", throwIfNotFound: true);
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

        // Build
        private readonly InputActionMap m_Build;
        private IBuildActions m_BuildActionsCallbackInterface;
        private readonly InputAction m_Build_Move;
        private readonly InputAction m_Build_Fly;
        private readonly InputAction m_Build_Act1;
        private readonly InputAction m_Build_Act2;
        private readonly InputAction m_Build_ActPos;
        private readonly InputAction m_Build_Look;
        private readonly InputAction m_Build_Scroll;
        private readonly InputAction m_Build_Change;
        public struct BuildActions
        {
            private @Input m_Wrapper;
            public BuildActions(@Input wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Build_Move;
            public InputAction @Fly => m_Wrapper.m_Build_Fly;
            public InputAction @Act1 => m_Wrapper.m_Build_Act1;
            public InputAction @Act2 => m_Wrapper.m_Build_Act2;
            public InputAction @ActPos => m_Wrapper.m_Build_ActPos;
            public InputAction @Look => m_Wrapper.m_Build_Look;
            public InputAction @Scroll => m_Wrapper.m_Build_Scroll;
            public InputAction @Change => m_Wrapper.m_Build_Change;
            public InputActionMap Get() { return m_Wrapper.m_Build; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(BuildActions set) { return set.Get(); }
            public void SetCallbacks(IBuildActions instance)
            {
                if (m_Wrapper.m_BuildActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_BuildActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_BuildActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_BuildActionsCallbackInterface.OnMove;
                    @Fly.started -= m_Wrapper.m_BuildActionsCallbackInterface.OnFly;
                    @Fly.performed -= m_Wrapper.m_BuildActionsCallbackInterface.OnFly;
                    @Fly.canceled -= m_Wrapper.m_BuildActionsCallbackInterface.OnFly;
                    @Act1.started -= m_Wrapper.m_BuildActionsCallbackInterface.OnAct1;
                    @Act1.performed -= m_Wrapper.m_BuildActionsCallbackInterface.OnAct1;
                    @Act1.canceled -= m_Wrapper.m_BuildActionsCallbackInterface.OnAct1;
                    @Act2.started -= m_Wrapper.m_BuildActionsCallbackInterface.OnAct2;
                    @Act2.performed -= m_Wrapper.m_BuildActionsCallbackInterface.OnAct2;
                    @Act2.canceled -= m_Wrapper.m_BuildActionsCallbackInterface.OnAct2;
                    @ActPos.started -= m_Wrapper.m_BuildActionsCallbackInterface.OnActPos;
                    @ActPos.performed -= m_Wrapper.m_BuildActionsCallbackInterface.OnActPos;
                    @ActPos.canceled -= m_Wrapper.m_BuildActionsCallbackInterface.OnActPos;
                    @Look.started -= m_Wrapper.m_BuildActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m_BuildActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m_BuildActionsCallbackInterface.OnLook;
                    @Scroll.started -= m_Wrapper.m_BuildActionsCallbackInterface.OnScroll;
                    @Scroll.performed -= m_Wrapper.m_BuildActionsCallbackInterface.OnScroll;
                    @Scroll.canceled -= m_Wrapper.m_BuildActionsCallbackInterface.OnScroll;
                    @Change.started -= m_Wrapper.m_BuildActionsCallbackInterface.OnChange;
                    @Change.performed -= m_Wrapper.m_BuildActionsCallbackInterface.OnChange;
                    @Change.canceled -= m_Wrapper.m_BuildActionsCallbackInterface.OnChange;
                }
                m_Wrapper.m_BuildActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Fly.started += instance.OnFly;
                    @Fly.performed += instance.OnFly;
                    @Fly.canceled += instance.OnFly;
                    @Act1.started += instance.OnAct1;
                    @Act1.performed += instance.OnAct1;
                    @Act1.canceled += instance.OnAct1;
                    @Act2.started += instance.OnAct2;
                    @Act2.performed += instance.OnAct2;
                    @Act2.canceled += instance.OnAct2;
                    @ActPos.started += instance.OnActPos;
                    @ActPos.performed += instance.OnActPos;
                    @ActPos.canceled += instance.OnActPos;
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                    @Scroll.started += instance.OnScroll;
                    @Scroll.performed += instance.OnScroll;
                    @Scroll.canceled += instance.OnScroll;
                    @Change.started += instance.OnChange;
                    @Change.performed += instance.OnChange;
                    @Change.canceled += instance.OnChange;
                }
            }
        }
        public BuildActions @Build => new BuildActions(this);
        public interface IBuildActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnFly(InputAction.CallbackContext context);
            void OnAct1(InputAction.CallbackContext context);
            void OnAct2(InputAction.CallbackContext context);
            void OnActPos(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnScroll(InputAction.CallbackContext context);
            void OnChange(InputAction.CallbackContext context);
        }
    }
}
