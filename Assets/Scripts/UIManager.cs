using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text ScoreText;
    public Text BestScoreText;

    public GameObject GameOverText;

    private int score = 0;
    private int bestScore = 0;
    private string playerName = "";
    private string bestScoreName = "";
    private bool isNewBestScore = false;

    private void OnEnable()
    {
        EventManager.Instance.OnScoreUpdate += UpdateScoreText;
        EventManager.Instance.OnGameOver += UpdateGameOverText;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnScoreUpdate -= UpdateScoreText;
        EventManager.Instance.OnGameOver -= UpdateGameOverText;
    }

    // Start is called before the first frame update
    void Start()
    {
        isNewBestScore = false;
        bestScore = MainManager.Instance.bestScore;
        playerName = MainManager.Instance.playerName;
        bestScoreName = MainManager.Instance.bestScoreName;
        UpdateScoreText(0);
        UpdateBestScoreText(MainManager.Instance.bestScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateScoreText(int points)
    {
        score += points;
        ScoreText.text = $"Score : {playerName} {score}";
        if(score > bestScore)
        {
            Debug.Log("Updating best score! Congrats.");
            UpdateBestScoreText(score);
        }
    }

    private void UpdateBestScoreText(int score)
    {
        bestScore = score;

        if (this.score == score) {
            isNewBestScore = true;
            bestScoreName = playerName;
        }

        BestScoreText.text = $"Best Score: {bestScoreName} {score}";
    }

    private void UpdateGameOverText()
    {
        if (isNewBestScore)
        {
            Debug.Log("Game Over! But new highscore!");
            MainManager.Instance.UpdateBestScore(score);
        }
        GameOverText.SetActive(true);
    }
}
