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
    

    // Use this for initialization
    void Start()
    {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        audioplay = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        bool isBreakable = (this.tag == "Block");
        if (isBreakable)
        {
            handleHits();
        }
       
    }

    void handleHits()
    {
        timesHit++;
        maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            Instantiate (smoke, new Vector3 (this.transform.position.x, this.transform.position.y, -1f), Quaternion.identity);
            AudioSource.PlayClipAtPoint(ballbreak, transform.position);
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
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
