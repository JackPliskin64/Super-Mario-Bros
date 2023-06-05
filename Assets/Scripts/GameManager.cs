using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score;
    public TMP_Text scoreText;
    public TMP_Text gameoverText;
    public TMP_Text winText;

    public bool gameOver = false;
    public bool win = false;

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
            StartCoroutine(ReloadGame());
        }

        if(win)
        {
            winText.gameObject.SetActive(true);
            StartCoroutine(backToMenu());
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

    IEnumerator ReloadGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Level01");
    }

    IEnumerator backToMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }
}
