using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    private AudioSource audioplay;
    private bool hasStarted = false;

    void Start()
    {
        audioplay = GetComponent<AudioSource>();
    }
    void Update() {
        Vector3 paddlePos = new Vector3(1.2f, this.transform.position.y, 0f);
        float MousePosBlocks = (Input.mousePosition.x / Screen.width)*19;
        paddlePos.x = Mathf.Clamp(MousePosBlocks, 1.2f,18.0f);
        this.transform.position = paddlePos;

        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
        }
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

