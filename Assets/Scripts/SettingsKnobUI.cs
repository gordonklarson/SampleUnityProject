using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsKnobUI : MonoBehaviour
{
    private bool buttonDown = false;
    private float rotationAmount;
    private float rotationDelta;
    /// <summary>
    /// Rotate the knob everytime it's clicked
    /// </summary>
    public void OnClickDown(float amount)
    {
        buttonDown = true;
        rotationAmount = amount;
    }

    public void OnClickUp()
    {
        buttonDown = false;
    }

    public void Update()
    {
        if (buttonDown)
        {
            rotationDelta = rotationAmount * Time.deltaTime;

            transform.Rotate(0.0f, 0.0f, rotationDelta, Space.Self);
            GameManager.Instance.SettingsKnobClicked(rotationDelta);
        }
    }

    /// <summary>
    /// Gets the rotation of the settings knob around the Z-Axis
    /// </summary>
    /// <returns>The euler angle of the z rotation for this knob</returns>
    public float GetKnobRotation()
    {
        return transform.localEulerAngles.z;
    }
}
