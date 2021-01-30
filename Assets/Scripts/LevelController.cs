using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int blockNum;
    SceneLoader nextLevel;
    
    private void Start()
    {
        nextLevel = FindObjectOfType<SceneLoader>();
    }
    public void CountBlocks()
    {
        blockNum++;
    }
    public void BlocksDestroyed()
    {
        blockNum--;
        if(blockNum<=0)
        {
            nextLevel.LoadNextLevel();
        }
    }
}
