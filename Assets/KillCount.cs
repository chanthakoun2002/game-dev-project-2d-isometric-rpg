using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;

    private void Start()
    {
        LoadScore();
        UpdateScoreText();
    }

    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        UpdateScoreText();
        SaveScore();
    }
    public void defaultScore()
    {
        playerScore = 0;
        UpdateScoreText();
        PlayerData.SavePlayerScore(playerScore);
    }

    private void UpdateScoreText()
    {
        scoreText.text = playerScore.ToString();
    }

    private void SaveScore()
    {
        PlayerData.SavePlayerScore(playerScore);
    }

    private void LoadScore()
    {
        playerScore = PlayerData.LoadPlayerScore();
    }

    // private void Update()//for testing purposes to see that the text is updating
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         AddScore(10); //add 10 to the score when space key is pressed
    //     }
    // }
}