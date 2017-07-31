using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class JumpGame : Game
{
    [SerializeField]
    private JumpPlayerController playerController;

    [SerializeField]
    private Camera jumpGameCamera;

    /// <summary>
    /// Array of GameObjects that hold the graphical representation of the players health as hearts.
    /// </summary>
    [SerializeField]
    private GameObject[] hearts;

    /// <summary>
    /// UI text showing the amount of elapsed time the game has been played for.
    /// </summary>
    [SerializeField]
    private TextMesh timerText;

    /// <summary>
    /// Players health. Once this reaches 0 the game is over.
    /// </summary>
    private int health = 3;


    /// <summary>
    /// The PostProcessingProfile used by the jump game camera.
    /// </summary>
    private PostProcessingProfile ppb;

    /// <summary>
    /// used to store and modify the GrainModel associated with ppb.
    /// </summary>
    private GrainModel.Settings grainSettings;

    /// <summary>
    /// Amount of time the player has been playing since the round started.
    /// </summary>
    private float playTime = 0.0f;
    

    public void Awake()
    {
        ppb = jumpGameCamera.GetComponent<PostProcessingBehaviour>().profile;
        grainSettings = ppb.grain.settings;

        //initialize grain settings to 1.0f at start.
        grainSettings.intensity = 1.0f;
        ppb.grain.settings = grainSettings;
    }

    public void Update()
    {
        if (!gameOver)
        {
            playTime += Time.deltaTime;
            timerText.text = "Time: " + playTime.ToString("0.00");
        }
    }


    /// <summary>
    /// Decrease health by 1, check for gameover state, and update the health UI
    /// </summary>
    public void ReduceHealth()
    {
        health--;
        hearts[health].SetActive(false);
        if (health <= 0)
        {
            GameOver();
        }
    }

    /// <summary>
    /// Change the intensity of the grain camera effect based on the amount the settings knob has been turned.
    /// </summary>
    /// <param name="amount"></param>
    public override void SettingsKnobTurned(float amount)
    {
        imageEffectValue += amount;
        grainSettings.intensity = (Mathf.Cos(Mathf.Deg2Rad * imageEffectValue) + 1.0f) / 2.0f;
        ppb.grain.settings = grainSettings;
    }

    public override void Reset()
    {
        base.Reset();
        playerController = FindObjectOfType<JumpPlayerController>();
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(true);
        }
        health = 3;
        playTime = 0.0f;
    }
}
