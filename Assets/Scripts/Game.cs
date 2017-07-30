using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Game : MonoBehaviour
{
    [SerializeField]
    protected Material screenMaterial;

    protected bool gameOver = false;

    protected float imageEffectValue = 0.0f;
    
    public virtual void OnEnable()
    {
        SetupVisualEffects();
    }

    protected virtual void SetupVisualEffects()
    {
        if (screenMaterial != null)
        {
            GameManager.Instance.SetScreenMaterial(screenMaterial);
        }
    }

    public virtual void EnableGame()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void DisableGame()
    {
        this.gameObject.SetActive(false);
    }

    public abstract void GameOver();

    public abstract void SettingsKnobTurned(float updatedVal);
    
}
