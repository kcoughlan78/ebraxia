using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

    public Slider VolumeSlider;
    private LevelManager levelManager;
    private MusicPlayer musicplayer;

    void Start()
    {
        musicplayer = GameObject.FindObjectOfType<MusicPlayer>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        VolumeSlider.value = PlayerPrefMgt.GetMasterVolume();
    }

    public void VolControl()
    {
        PlayerPrefMgt.SetMasterVolume(VolumeSlider.value);
        print("vol is " + VolumeSlider.value);
        levelManager.LoadLevel("StartScreen");
    }

    public void VolReset()
    {
        VolumeSlider.value = 0.5f;
    }
}
