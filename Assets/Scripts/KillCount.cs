using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public static KillCount instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadScore();
        UpdateScoreText();
    }

    public void AddScore(int scoreToAdd) //when an enemy dies it will add a score or count here 
    {
        playerScore += scoreToAdd;
        UpdateScoreText();
        SaveScore();
    }
    public void DefaultScore()  //reset the score for when a new game is started or game is exited
    {
        playerScore = 0;
        //UpdateScoreText();
        PlayerData.SavePlayerScore(playerScore);
    }

    private void UpdateScoreText()
    {
        scoreText.text = playerScore.ToString();
    }

    private void SaveScore() //each time a score is added iot will save and carry over to to other scenes
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