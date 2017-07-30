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

    private PostProcessingProfile ppb;

    private GrainModel.Settings grainSettings;
    

    public void Awake()
    {
        ppb = jumpGameCamera.GetComponent<PostProcessingBehaviour>().profile;
        grainSettings = ppb.grain.settings;

        //initialize grain settings to 1.0f at start.
        grainSettings.intensity = 1.0f;
        ppb.grain.settings = grainSettings;
    }

    public override void GameOver()
    {
        throw new System.NotImplementedException();
    }

    public override void SettingsKnobTurned(float amount)
    {
        imageEffectValue += amount;
        grainSettings.intensity = (Mathf.Cos(Mathf.Deg2Rad * imageEffectValue) + 1.0f) / 2.0f;
        ppb.grain.settings = grainSettings;
    }
}
