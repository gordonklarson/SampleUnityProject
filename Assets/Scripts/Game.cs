using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Game : MonoBehaviour
{
    [SerializeField]
    protected Material screenMaterial;

    [SerializeField]
    protected GameObject gameOverScreen;

    [SerializeField]
    protected GameObject gameAssets;

    [SerializeField]
    protected GameObject gameAssetsPrefab;

    protected bool gameOver = false;

    protected float imageEffectValue = 0.0f;
    
    public virtual void OnEnable()
    {
        SetupVisualEffects();
        Reset();
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

    public virtual void Reset()
    {
        if (gameAssets != null)
        {
            Destroy(gameAssets);
        }
        gameOverScreen.SetActive(false);
        gameAssets = Instantiate(gameAssetsPrefab, transform);
        gameOver = false;
    }

    public virtual void GameOver()
    {
        gameOver = true;
        Destroy(gameAssets);
        gameOverScreen.SetActive(true);
    }

    public abstract void SettingsKnobTurned(float updatedVal);
    
}
