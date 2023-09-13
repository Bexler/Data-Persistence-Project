using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateHighscore()
    {
        bestScoreText.text = "Best Score: " + MainManager.Instance.bestScoreName + " " + MainManager.Instance.bestScore;
    }

    public void ResetHighscore()
    {
        MainManager.Instance.ResetBestScore();
        UpdateHighscore();
    }

    public void UpdatePlayerName()
    {
        MainManager.Instance.playerName = nameInput.text;
    }

    public void Exit()
    {
        MainManager.Instance.saveScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
