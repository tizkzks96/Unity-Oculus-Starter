using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class XR_ControllerBase : MonoBehaviour
{
    public XRController leftHandController;
    public XRController rightHandController;
    public static XR_ControllerBase instance;
    // left , right
    List<InputDevice> inputDeviceControllers = new List<InputDevice>();
    // left , right
    List<XRController> controllers = new List<XRController>();
    // controller animator
    //List<Animator> controllerAnimator = new List<Animator>();

    public bool isControllerReady = false;

    InputDevice leftCont;
    InputDevice rightCont;

    private void Awake()
    {
        if (instance != null) Destroy(instance);
        instance = this;
    }

    void Start()
    {
        Init();
    }
    void Init()
    {
        SetInputDeviceController(EnumDefinition.ControllerType.RightController); // device
    }

    InputDevice SetInputDeviceController(EnumDefinition.ControllerType controllerType)
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDeviceCharacteristics controller;
        controller = controllerType == EnumDefinition.ControllerType.LeftController ? InputDeviceCharacteristics.Left : InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(controller, devices);
        if (devices.Count > 0)
            return devices[0];
        else
            return new InputDevice();

    }

    private void Update()
    {
        if (!leftCont.isValid)
            leftCont = SetInputDeviceController(EnumDefinition.ControllerType.LeftController);
        if (!rightCont.isValid)
            rightCont = SetInputDeviceController(EnumDefinition.ControllerType.RightController);

        if (leftCont.isValid && rightCont.isValid && inputDeviceControllers.Count <= 0)
        {
            inputDeviceControllers.Add(leftCont);
            inputDeviceControllers.Add(rightCont);
            SetControllers(); // scene controller
            isControllerReady = true;
        }

        VRControllerInput.GetGripButton(rightCont, () => { Debug.Log("GetGripButton 1"); }, () => { Debug.Log("GetGripButton 2 "); }, () => { Debug.Log("GetGripButton 3 "); });
        VRControllerInput.GetTriggerButton(rightCont, () => { Debug.Log("Trigger 1"); }, () => { Debug.Log("Trigger 2 "); }, () => { Debug.Log("Trigger 3 "); });
        VRControllerInput.GetPrimaryButton(rightCont, () => { Debug.Log("GetPrimaryButton 1"); }, () => { Debug.Log("GetPrimaryButton 2 "); }, () => { Debug.Log("GetPrimaryButton 3 "); });
        VRControllerInput.GetSecondaryButton(rightCont, () => { Debug.Log("GetSecondaryButton 1"); }, () => { Debug.Log("GetSecondaryButton 2 "); }, () => { Debug.Log("GetSecondaryButton 3 "); });


    }


    void SetControllers()
    {
        controllers.Add(leftHandController);
        controllers.Add(rightHandController);
    }

    public XRController GetController(EnumDefinition.ControllerType controllerType)
    {
        return controllers[(int)controllerType];
    }

    public InputDevice GetInputDeviceController(EnumDefinition.ControllerType controllerType)
    {
        return inputDeviceControllers[(int)controllerType];
    }
}
