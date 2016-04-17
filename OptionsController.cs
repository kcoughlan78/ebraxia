using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

    public Slider VolumeSlider;
    public Dropdown ControlDrop;
    private LevelManager levelManager;
    private MusicPlayer musicplayer;

    void Start()
    {
        musicplayer = GameObject.FindObjectOfType<MusicPlayer>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        VolumeSlider.value = PlayerPrefMgt.GetMasterVolume();
        ControlDrop.value = PlayerPrefMgt.GetControl();
    }

    public void SaveAndExit()
    {
        PlayerPrefMgt.SetMasterVolume(VolumeSlider.value);
        PlayerPrefMgt.SetControl(ControlDrop.value);
        print("vol is " + VolumeSlider.value);
        levelManager.LoadLevel("StartScreen");
    }

    public void Reset()
    {
        VolumeSlider.value = 0.5f;
        ControlDrop.value = 0;
    }
}
