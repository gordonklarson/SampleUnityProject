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

    public void SetScreenMaterial(Material material)
    {
        screenImage.material = material;
    }

    public Material GetScreenMaterial()
    {
        return screenImage.material;
    }

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
