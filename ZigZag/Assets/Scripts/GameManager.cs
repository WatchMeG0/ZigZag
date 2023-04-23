using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI highscoreText;

    private void Awake()
    {
        highscoreText.text = "Best: " + GetHighScore().ToString();
    }
    public void StartGame()
    {
        gameStarted = true;
        FindAnyObjectByType<Road>().StartBuilding();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
    public void IncreaseScore()
    {
        score++;
        ScoreText.text = score.ToString();

        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = "Best: "+score.ToString();
        }
    }
    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("Highscore");
        return i;


    }
}
