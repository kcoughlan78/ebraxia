﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{

    private int maxHits;
    public Sprite[] hitSprites;
    private int timesHit;
    private LevelManager levelManager;
    private int blocks;

    

    // Use this for initialization
    void Start()
    {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        
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
        }
    }

   
}
