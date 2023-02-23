using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    public TextMeshProUGUI txtScore;
    public Image imgStart;
    public Image imgOver;
    public Button btnPlay;
    public Button btnRePlay;

    private int score = 0;

    private void Start()
    {
        Time.timeScale = 0f;
        txtScore.text = score.ToString();
    }

    public void PLayGame()
    {
        Time.timeScale = 1f;
        btnPlay.gameObject.SetActive(false);
        imgStart.gameObject.SetActive(false);
    }

    public void AddScore()
    {
        score++;
        txtScore.text = score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        imgOver.gameObject.SetActive(true);
        btnRePlay.gameObject.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
