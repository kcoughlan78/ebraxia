using UnityEngine;
using System.Collections;

public class BallMech : MonoBehaviour {

    private Paddle paddle;
    public Rigidbody2D rb2d;
    public bool hasStarted = false;
    private Vector3 paddleToBallVector;
    public float VelocityXMin = 3;
    public float VelocityXMax = 7;
    

	// Use this for initialization
	void Start () {
        BalltoPaddle();
	}

    public void BalltoPaddle()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        print(paddleToBallVector);
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                print("Clicked");
                hasStarted = true;
                this.rb2d.velocity = new Vector2(Random.Range(VelocityXMin, VelocityXMax), 16.2f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        this.rb2d.velocity += tweak;
    }
}
