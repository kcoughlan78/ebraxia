using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMgt : MonoBehaviour {

    public int playerLives;
    public Text text;
    public Text levelText;
    private LevelManager levelManager;
    private int sceneNumber;
    public GameObject Win;
    public GameObject Lose;
    private Paddle paddle;
    private float thisLevel;


    // Use this for initialization


    void Start () {
        playerLives = 3;
        Debug.Log(playerLives);
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        sceneNumber = SceneManager.GetActiveScene().buildIndex - 1;
        Win.SetActive(false);
        Lose.SetActive(false);
        paddle.autoplay = false;
        SetStartingLevelKey();
        Debug.Log("Level key is " + PlayerPrefMgt.GetLevelKey());
    }

    // Update is called once per frame
    void Update () {
        text.text = "Lives: " + playerLives;
        levelText.text = "Level: " + sceneNumber;
	}

    public void SetStartingLevelKey()
    {
        thisLevel = PlayerPrefMgt.GetLevelKey();
        if(thisLevel < 2)
        {
            PlayerPrefMgt.SetLevelKey(2);
        }
    }
}
