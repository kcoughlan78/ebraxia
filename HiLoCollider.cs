using UnityEngine;
using System.Collections;

public class HiLoCollider : MonoBehaviour {
    private LevelManager levelManager;
    private GameMgt gamemgt;
    private Brick brick;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        gamemgt = GameObject.FindObjectOfType<GameMgt>();
        brick = GameObject.FindObjectOfType<Brick>();

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
            gamemgt.playerLives = 0;
            levelManager.LoadLevel("Lose");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gamemgt.playerLives = 0;
        levelManager.LoadLevel("Lose");
    }
}
