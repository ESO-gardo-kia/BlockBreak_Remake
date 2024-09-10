using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject clearText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI resultScore;
    [SerializeField] TextMeshProUGUI resultTime;
    [SerializeField] TextMeshProUGUI resultLife;
    [SerializeField] TextMeshProUGUI resultTotalScore;
    [SerializeField] GameObject resultRoot;
    [SerializeField] TextMeshProUGUI highScoreUI;
    public void ShowResult(int score,int highScore,int ballCount,int timeLimit)
    {
        clearText.SetActive(true);
        resultRoot.SetActive(true);
        resultScore.text = "Score: " + score;
        resultTime.text = "Time: " + Mathf.RoundToInt(timeLimit) + "x 100 = " + Mathf.RoundToInt(timeLimit) * 100;
        resultLife.text = "Life: " + ballCount + "x 500 = " + ballCount * 500;

        int toralScore = score + Mathf.RoundToInt(timeLimit) * 100 + ballCount * 500;
        resultTotalScore.text = "Total Score: " + toralScore;

        if (highScore < toralScore)
        {
            highScore = toralScore;
            highScoreUI.text = "High Score: " + highScore;
        }
    }
    public void UiFirstProcessing()
    {
        SetScoreText(0);
        gameOverText.SetActive(false);
        clearText.SetActive(false);
        resultRoot.SetActive(false);
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }
    public void SetTimeEvent(int timeLimit)
    {
        timerText.text = "Time: " + Mathf.RoundToInt(timeLimit);
    }
    public void TimeOverEvent()
    {
        GameManager.inGame = false;
        timerText.text = "Time: 0";
        gameOverText.SetActive(true);
    }
    public void NoRemainingBall()
    {
        gameOverText.SetActive(true);
    }
}
