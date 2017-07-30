using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGame : Game
{
    public void Awake()
    {
        GameManager.Instance.GetScreenMaterial().SetFloat("_Strength", 1.0f);
    }
    public override void GameOver()
    {
        throw new System.NotImplementedException();
    }

    public override void SettingsKnobTurned(float amount)
    {
        imageEffectValue += amount;
        GameManager.Instance.GetScreenMaterial().SetFloat("_Strength", (Mathf.Cos(Mathf.Deg2Rad * imageEffectValue) + 1.0f) / 2.0f);
    }
}
