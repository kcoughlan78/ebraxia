using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefMgt : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    const string CONTROL_KEY = "control_";

    public static void SetMasterVolume (float volume)
    {
        if (volume >= 0f && volume <=1f) { 
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else
        {
            Debug.LogError("Master Volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel (int level)
    {
        if (level <= SceneManager.GetActiveScene().buildIndex - 2)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        } else
        {
            Debug.LogError("Level out of range");
        }
    }


    public static void SetLevelKey(int level)
    {
        if (level >= 2)
        {
            PlayerPrefs.SetInt(LEVEL_KEY, level);
        }
        else
        {
            Debug.LogError("Level out of range");
        }
    }

    public static int GetLevelKey()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY);
    }

    public static void SetControl (int control)
    {
        if (control >= 0 && control <= 1)
        {
            PlayerPrefs.SetInt(CONTROL_KEY, control);
        }
        else
        {
            Debug.LogError("Controls out of range");
        }
    }

    public static int GetControl()
    {
        return PlayerPrefs.GetInt(CONTROL_KEY);
    }



}
