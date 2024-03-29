﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreDisplay;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount>1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreDisplay.text = currentScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        scoreDisplay.text = currentScore.ToString();
    }
    public void AddToScore()
    {
        currentScore = currentScore + pointsPerBlockDestroyed;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
