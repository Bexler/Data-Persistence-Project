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
        bestScore = MainManager.Instance.bestScore;
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
        ScoreText.text = $"Score : {score}";
        if(score > bestScore)
        {
            UpdateBestScoreText(score);
        }
    }

    private void UpdateBestScoreText(int score)
    {
        bestScore = score;
        isNewBestScore = true;
        BestScoreText.text = $"Best Score : {score}";
    }

    private void UpdateGameOverText()
    {
        if (isNewBestScore)
        {
            MainManager.Instance.UpdateBestScore(score);
        }
        GameOverText.SetActive(true);
    }
}
