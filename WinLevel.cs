using UnityEngine;
using System.Collections;

public class WinLevel : MonoBehaviour {

    private int brickcount;
    private LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();

    }

    void Update()
    {
        brickcount = GameObject.FindGameObjectsWithTag("Block").Length;
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
