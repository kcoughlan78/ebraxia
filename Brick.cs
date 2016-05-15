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
    string[] brickArray = new string[] { "Rezos", "Altosz", "ElTerras", "Guolz" };
    public bool GoulzLeft;
    

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
