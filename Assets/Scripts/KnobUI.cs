using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobUI : MonoBehaviour
{
    /// <summary>
    /// Angle around the z-axis to rotate the knob on click. 
    /// </summary>
    [SerializeField]
    private float clickRotation = 45.0f;

    /// <summary>
    /// Rotate the knob everytime it's clicked
    /// </summary>
    public void OnClick()
    {
        transform.Rotate(0.0f, 0.0f, clickRotation);
    }
}
