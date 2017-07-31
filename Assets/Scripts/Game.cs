using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Game : MonoBehaviour
{
    /// <summary>
    /// Material to be used by the object displaying the RenderTexture rendering the game camera.
    /// </summary>
    [SerializeField]
    protected Material screenMaterial;

    /// <summary>
    /// Parent object to be activated when the game over state has been reached.
    /// </summary>
    [SerializeField]
    protected GameObject gameOverScreen;

    /// <summary>
    /// Game specific assets used for gameplay
    /// </summary>
    [SerializeField]
    protected GameObject gameAssets;

    /// <summary>
    /// Prefab object containing game specific assets used for gameplay
    /// </summary>
    [SerializeField]
    protected GameObject gameAssetsPrefab;

    /// <summary>
    /// Is the game in the game over state.
    /// </summary>
    protected bool gameOver = false;

    /// <summary>
    /// Strength of the postprocessing or shader effect used when rendering this game.
    /// </summary>
    protected float imageEffectValue = 0.0f;
    
    public virtual void OnEnable()
    {
        SetupVisualEffects();
        Reset();
    }

    /// <summary>
    /// Setup visual effects for this game
    /// </summary>
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

    /// <summary>
    /// Reset the game to it's initial start state.
    /// </summary>
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

    /// <summary>
    /// Called when the game over state has been reached.
    /// </summary>
    public virtual void GameOver()
    {
        gameOver = true;
        Destroy(gameAssets);
        gameOverScreen.SetActive(true);
    }

    /// <summary>
    /// Called when the settings knob has been turned by the player.
    /// </summary>
    /// <param name="updatedVal">Value in degrees the settings knob has been turned.</param>
    public abstract void SettingsKnobTurned(float updatedVal);
    
}
