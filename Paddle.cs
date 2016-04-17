using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    private AudioSource audioplay;
    private bool hasStarted = false;
    public bool autoplay = false;
    private BallMech ball;
    //below var setting for keyboard controls
    public int ControlSettings;
    private float speed = 10.0f;
    float xmin;
    float xmax;
    public float padding = 1f;

    void Start()
    {
        audioplay = GetComponent<AudioSource>();
        ball = GameObject.FindObjectOfType<BallMech>();
        ControlSettings = PlayerPrefMgt.GetControl();// options 0 = Mouse 1 = KB
        //below setting for keyboard controls
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }
    void Update() {

        if (!autoplay && ControlSettings < 1)
        {
                PaddlePlay();
        } else if (!autoplay && ControlSettings > 0)
        {

            KBStart();
            PaddlePlayKB();
        } else
        {
            PlayTest();
        }
        
    }

    void PaddlePlay() // paddle control with mouse
    {
        Vector3 paddlePos = new Vector3(1.2f, this.transform.position.y, 0f);
        float MousePosBlocks = (Input.mousePosition.x / Screen.width) * 19;
        paddlePos.x = Mathf.Clamp(MousePosBlocks, 1.2f, 18.0f);
        this.transform.position = paddlePos;

        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
        }
    }

    void PaddlePlayKB() // paddle control with keyboard
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        
        // restrict the player to the gamespace
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

        void KBStart() //Start gamme if KB setting true
    {
        if (Input.GetKeyDown("space"))
        {
            hasStarted = true;
            print("Yep");
        }
    }

void PlayTest()
    {
        Vector3 paddlePos = new Vector3(1.2f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 1.2f, 18.0f);
        this.transform.position = paddlePos;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collide");
        if (hasStarted)
        {
            audioplay.Play();
        }
    }
}

