using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Game : MonoBehaviour
{

    public Material screenMaterial;

    protected bool gameOver = false;

    public void OnEnable()
    {
        SetupVisualEffects();
    }

    protected virtual void SetupVisualEffects()
    {
        GameManager.Instance.SetScreenMaterial(screenMaterial);
    }

    public virtual void EnableGame()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void DisableGame()
    {
        this.gameObject.SetActive(false);
    }

    protected abstract void OnGameOver();

    public abstract void SettingsKnobTurned(float amount);
}
