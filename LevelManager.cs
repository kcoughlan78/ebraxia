using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevel;
    public bool autoLoad = false;
    


    void Start()
    {
        float currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentScene);


        if (autoLoad)
        {
            Invoke("LoadNextLevel", autoLoadNextLevel);
        }
    }

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitLevel()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void ReturnToStart(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void loadLevelIndex()
    {
        SceneManager.LoadScene("level_menu");
    }

    public void loadRequestedLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
