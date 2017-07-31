using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Image object displaying the render texture used for rendering the game camera.
    /// </summary>
    [SerializeField]
    private RawImage screenImage;

    /// <summary>
    /// Parent scene objects for each minigame
    /// </summary>
    [SerializeField]
    private Game[] games;
    
    /// <summary>
    /// The channel determines what game is currently being played.
    /// </summary>
    private int channel = 0;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }


    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    /// <summary>
    /// Set the material used by the "TV Screen" scene object
    /// </summary>
    /// <param name="material"></param>
    public void SetScreenMaterial(Material material)
    {
        screenImage.material = material;
    }

    /// <summary>
    /// Get the material currently used by the "TV Screen" scene object
    /// </summary>
    /// <returns></returns>
    public Material GetScreenMaterial()
    {
        return screenImage.material;
    }

    /// <summary>
    /// Get the currently active minigame
    /// </summary>
    /// <returns>The Game object that is currently active</returns>
    public Game GetCurrentGame()
    {
        return games[channel];
    }

    public void ChannelKnobClicked()
    {
        games[channel].DisableGame();
        channel = (channel + 1) % games.Length;
        games[channel].EnableGame();
    }

    public void SettingsKnobClicked(float amount)
    {
        games[channel].SettingsKnobTurned(amount);
    }
}
