using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TicTacToeGame : Game
{

    public GameObject defaultFocus;

    public override void OnEnable()
    {
        base.OnEnable();
        EventSystem.current.SetSelectedGameObject(defaultFocus, null);
        
    }

    public void Awake()
    {
        GameManager.Instance.GetScreenMaterial().SetFloat("_Strength", 2.0f);
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            EventSystem.current.SetSelectedGameObject(defaultFocus, null);
        }
    }

    public override void GameOver()
    {
        throw new System.NotImplementedException();
    }

    public override void SettingsKnobTurned(float amount)
    {
        imageEffectValue += amount;
        GameManager.Instance.GetScreenMaterial().SetFloat("_Strength", (Mathf.Cos(Mathf.Deg2Rad * imageEffectValue) + 1.0f));
    }
}
