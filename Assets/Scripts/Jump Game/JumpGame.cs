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

    [SerializeField]
    private GameObject[] hearts;

    [SerializeField]
    private TextMesh timerText;

    private int health = 3;

    private PostProcessingProfile ppb;

    private GrainModel.Settings grainSettings;

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



    public void ReduceHealth()
    {
        health--;
        hearts[health].SetActive(false);
        if (health <= 0)
        {
            GameOver();
        }
    }

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
