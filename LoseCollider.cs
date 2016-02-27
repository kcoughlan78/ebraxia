using UnityEngine;
using System.Collections;


public class LoseCollider : MonoBehaviour {
    private LevelManager levelManager;
    private BallMech ball;
    private Paddle paddle;
    private GameMgt gamemgt;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        ball = GameObject.FindObjectOfType<BallMech>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        gamemgt = GameObject.FindObjectOfType<GameMgt>();
    }
    

    void OnTriggerEnter2D (Collider2D trigger)
    {
        print ("Collide");
        if (gamemgt.playerLives >= 1)
        {
            gamemgt.playerLives--;
            print(gamemgt.playerLives);
            ball.hasStarted = false;
            Vector3 ballReset = new Vector3(paddle.transform.position.x, paddle.transform.position.y + 0.24f, 0f);
            ball.transform.position = ballReset;
            ball.BalltoPaddle();
        }
        else
        {
            levelManager.LoadLevel("Lose");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print ("Collision");
    }

}
