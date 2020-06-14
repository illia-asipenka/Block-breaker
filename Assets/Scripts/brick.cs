using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    public static int breakableCount;
    public Sprite[] hitSptrites;
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

    private void Awake()
    {
        breakableCount = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        isBreakable = (this.tag == "breakable");
        //keep track of breakable bricks
        if(isBreakable)
        {
            breakableCount++;
        }
        Debug.Log(breakableCount);
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        bool isBreakable = (this.tag == "breakable");
        if (isBreakable)
        {
            HandleHits();

        }
    }

    void HandleHits()
    {
        int maxHits = hitSptrites.Length + 1;
        timesHit += 1;
        //SimulateWin();
        if (timesHit >= maxHits)
        {
            breakableCount--;
            Debug.Log(breakableCount);
            levelManager.BrickDestroyed();
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
        if (hitSptrites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSptrites[spriteIndex];
        }
    }

    private void SimulateWin()
    {
        levelManager.LoadNextLevel();

    }
}
