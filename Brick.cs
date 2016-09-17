using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{

    private int maxHits;
    public Sprite[] hitSprites;
    private int timesHit;
    private LevelManager levelManager;
    private int blocks;
    private AudioSource audioplay;
    public AudioClip ballbreak;
    public GameObject smoke;
    string[] brickArray = new string[] { "Rezos", "Altosz", "Elterras", "Guolz" };
    public bool GoulzLeft;
    private bool movingRight = true;
    public float width = 16;
    public float height = 5;
    public float speed = 2;
    public float gforce = 0.2f;
    private float startForm;
    private float goulzXMin; // for brick movement to Ebraxia
    private float goulzXMax; // for brick movement to Ebraxia


    // Use this for initialization
    void Start()
    {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        audioplay = GetComponent<AudioSource>();
        formOrganiser();

        if (GoulzLeft)
        {
            movingRight = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        goulzFormation();
        ATFormation();
    }

    void formOrganiser() // for brick movement to Ebraxia
    {
        if (this.tag == "Guolz") {

            if (GoulzLeft) {

                startForm = 0;

            }else
            {
                startForm = 1;
            }
        
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftedge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightedge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        goulzXMin = leftedge.x;
        goulzXMax = rightedge.x;
        }
    }

    void goulzFormation()// for brick movement to Ebraxia
    {
        if (this.tag == "Guolz")
        {
            if (transform.position.x >= (goulzXMax - (width / 2)))
            {
                movingRight = false;
            }
            else if (transform.position.x <= (goulzXMin + (width / 2)))
            {
                movingRight = true;
            }

            if (movingRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
    }

    void ATFormation()
    {
        if (this.tag == "Altosz")
        {
            transform.position += Vector3.up * gforce * Time.deltaTime;
        }else if (this.tag == "Elterras")
        {
            transform.position += Vector3.down * gforce * Time.deltaTime;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        string tagToCheck = this.tag;

        foreach (string x in brickArray)
        {
            if (x.Contains(tagToCheck))
            {
                handleHits();
            }
        }
       
    }

    
    void handleHits()
    {
        timesHit++;
        maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
            smokePuff.GetComponentInParent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            AudioSource.PlayClipAtPoint(ballbreak, transform.position);
            KillBrick();
        }
        else
        {
            LoadSprites();
        }
    }

    void KillBrick()
    {
        Destroy(gameObject);
    }


    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]) { 
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else
        {
            Debug.LogError("Missing Sprite");        } 
    }

   
}
