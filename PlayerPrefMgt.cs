using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefMgt : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

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


    public static bool isLevelUnlocked(int level)
    {
        int LevelBool = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (LevelBool == 1);
        if (level <= SceneManager.GetActiveScene().buildIndex - 2)
        {
            return isLevelUnlocked;
        } else
        {
            Debug.LogError("Level out of range");
            return false;
        }
    }

}
