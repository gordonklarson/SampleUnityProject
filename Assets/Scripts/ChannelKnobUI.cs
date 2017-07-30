using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChannelKnobUI: MonoBehaviour
{
    private float rotationAmount;

    /// <summary>
    /// Rotate the knob everytime it's clicked
    /// </summary>
    public void OnClick(float amount)
    {
        transform.Rotate(0.0f, 0.0f, amount);
    }

    public void OnClickUp()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
