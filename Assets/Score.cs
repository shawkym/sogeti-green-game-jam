using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public float score = 0;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public int levelIndex;

    private void OnEnable()
    {
        Hook.scoreChanged += ScoreChanged;
    }

    private void OnDisable()
    {
        Hook.scoreChanged -= ScoreChanged;
    }
    
    private void ScoreChanged(float obj)
    {
        score += obj;
        scoreText.text = "Score: " + score;
    }

    public float GetScore()
    {
       return score;
    }

    public void ShowGameOver()
    {
        
    }

    public void MoveToNextLevel()
    {
        if (levelIndex <= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            ShowYouWinMessage();
        }
    }

    private void ShowYouWinMessage()
    {
        
    }
}
