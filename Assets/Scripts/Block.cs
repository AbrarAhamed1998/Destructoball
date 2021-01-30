using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockHit;
    [SerializeField] GameObject sparklesVFX;
    [SerializeField] IconBehavior icon;
    [SerializeField] Sprite[] hitSprites;

    LevelController level;
    GameSession score;

    int timesHit;
    int r;
    private void Start()
    {
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        score = FindObjectOfType<GameSession>();
        level = FindObjectOfType<LevelController>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
            r = UnityEngine.Random.Range(0, 10);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag=="Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowHitSprites();
        }
    }

    private void ShowHitSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from hitSprites array"+gameObject.name);
        }
    }

    private void IconAppear()
    {
        if (icon != null)
        {
            if (r == 2)
            {
                Instantiate(icon, transform.position, transform.rotation);
            }
        }
    }

    private void DestroyBlock()
    {
        IconAppear();
        level.BlocksDestroyed();
        ScorePlaySFX();
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    private void ScorePlaySFX()
    {
        AudioSource.PlayClipAtPoint(blockHit, transform.position);
        score.AddToScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(sparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
