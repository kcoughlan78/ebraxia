using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour {

    private int brickcount;
    private LevelManager levelManager;
    private Brick brick;
    public GameObject Win;
    private Paddle paddle;
    private int currentLevel;
    private int highLevel;


    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        paddle = GameObject.FindObjectOfType<Paddle>();

    }

    void Update()
    {
        brickcount = GameObject.FindGameObjectsWithTag("Guolz").Length + GameObject.FindGameObjectsWithTag("Rezos").Length + GameObject.FindGameObjectsWithTag("Altosz").Length + GameObject.FindGameObjectsWithTag("Elterras").Length;
        Debug.Log("BC is " + brickcount);
        if (brickcount < 1)
        {
            SimulateWin();
        }
    }
    public void SimulateWin()
    {
        //levelManager.LoadLevel("level_menu"); //turn this on when ready
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        highLevel = PlayerPrefMgt.GetLevelKey();
        if (highLevel == currentLevel)
        {
            PlayerPrefMgt.SetLevelKey(currentLevel + 1);
            Win.SetActive(true);
            paddle.autoplay = true;
        }
        else
        {
            Win.SetActive(true);
            paddle.autoplay = true;
        }


    }
}
