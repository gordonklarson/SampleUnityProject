using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGame : Game
{
    public void Start()
    {
        GameManager.Instance.GetScreenMaterial().SetFloat("_Strength", 1.0f);
    }

    public override void SettingsKnobTurned(float amount)
    {
        imageEffectValue += amount;
        GameManager.Instance.GetScreenMaterial().SetFloat("_Strength", Mathf.Clamp(Mathf.Cos(Mathf.Deg2Rad * imageEffectValue) + 1.0f / 2.0f, 0.0f, 1.0f));
    }
}
