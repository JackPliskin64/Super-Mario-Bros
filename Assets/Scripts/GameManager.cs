using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score;
    public TMP_Text scoreText;
    public TMP_Text gameoverText;

    public bool gameOver = false;

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void Update()
    {
        if(gameOver)
        {
            gameoverText.gameObject.SetActive(true);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
