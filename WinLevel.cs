using UnityEngine;
using System.Collections;

public class WinLevel : MonoBehaviour {

    private int brickcount;
    private LevelManager levelManager;
    private Brick brick;

    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();

    }

    void Update()
    {
        brickcount = GameObject.FindGameObjectsWithTag("Guolz").Length + GameObject.FindGameObjectsWithTag("Rezos").Length + GameObject.FindGameObjectsWithTag("Altosz").Length + GameObject.FindGameObjectsWithTag("Elterras").Length;
        if (brickcount < 1)
        {
            SimulateWin();
        }
    }
    public void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
