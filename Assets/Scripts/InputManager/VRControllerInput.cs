using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControllerInput
{
    #region Grip
    private static bool isGripDown = false;
    public static void GetGripButton(InputDevice ctrl, UnityAction downEvents, UnityAction pressEvents, UnityAction upEvents)
    {
        if (ctrl.TryGetFeatureValue(CommonUsages.gripButton, out bool downValue) && downValue && !isGripDown)
        {
            downEvents?.Invoke();
            isGripDown = true;
        }

        if (isGripDown)
        {
            pressEvents?.Invoke();
        }

        if (ctrl.TryGetFeatureValue(CommonUsages.gripButton, out bool upValue) && !upValue && isGripDown)
        {
            upEvents?.Invoke();
            isGripDown = false;
        }
    }
    #endregion

    #region Trigger
    private static bool isTriggerDown = false;
    public static void GetTriggerButton(InputDevice ctrl, UnityAction downEvents, UnityAction pressEvents, UnityAction upEvents)
    {
        if (ctrl.TryGetFeatureValue(CommonUsages.triggerButton, out bool downValue) && downValue && !isTriggerDown)
        {
            downEvents?.Invoke();
            isTriggerDown = true;
        }

        if (isTriggerDown)
        {
            pressEvents?.Invoke();
        }

        if (ctrl.TryGetFeatureValue(CommonUsages.triggerButton, out bool upValue) && !upValue && isTriggerDown)
        {
            upEvents?.Invoke();
            isTriggerDown = false;
        }
    }
    #endregion

    #region primaryButton

    private static bool isPrimaryDown = false;
    public static void GetPrimaryButton(InputDevice ctrl, UnityAction downEvents, UnityAction pressEvents, UnityAction upEvents)
    {
        if (ctrl.TryGetFeatureValue(CommonUsages.primaryButton, out bool downValue) && downValue && !isPrimaryDown)
        {
            downEvents?.Invoke();
            isPrimaryDown = true;
        }

        if (isPrimaryDown)
        {
            pressEvents?.Invoke();
        }

        if (ctrl.TryGetFeatureValue(CommonUsages.primaryButton, out bool upValue) && !upValue && isPrimaryDown)
        {
            upEvents?.Invoke();
            isPrimaryDown = false;
        }
    }
    #endregion

    #region SecondaryButton
    private static bool isSecondaryDown = false;
    public static void GetSecondaryButton(InputDevice ctrl, UnityAction downEvents, UnityAction pressEvents, UnityAction upEvents)
    {
        if (ctrl.TryGetFeatureValue(CommonUsages.secondaryButton, out bool downValue) && downValue && !isSecondaryDown)
        {
            downEvents?.Invoke();
            isSecondaryDown = true;
        }

        if (isSecondaryDown)
        {
            pressEvents?.Invoke();
        }

        if (ctrl.TryGetFeatureValue(CommonUsages.secondaryButton, out bool upValue) && !upValue && isSecondaryDown)
        {
            upEvents?.Invoke();
            isSecondaryDown = false;
        }
    }

    #endregion
}
