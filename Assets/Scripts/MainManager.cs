using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{


    public static MainManager Instance { get; private set; }

    public int bestScore;

    public string bestScoreName;

    public string playerName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        loadScore();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Update()
    {
        
    }

    public void AddPoint(int point)
    {
        EventManager.Instance.ScoreUpdate(point);
    }

    public void GameOver()
    {
        EventManager.Instance.GameOver();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ResetBestScore()
    {
        playerName = "";
        UpdateBestScore(0);
    }

    public void UpdateBestScore(int score)
    {
        bestScore = score;
        bestScoreName = playerName;
        saveScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int savedScore;
        public string savedName;
    }

    public void saveScore()
    {
        SaveData data = new SaveData();
        data.savedScore = bestScore;
        data.savedName = bestScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Saved score to savedScore: " + data.savedScore);
    }

    public void loadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("Received savedScore: " + data.savedScore);
            bestScore = data.savedScore; 
            bestScoreName = data.savedName;
        } else
        {
            Debug.Log("Failed to receive savedScore, path not found");
            bestScore = 0;
            bestScoreName = "NoName";
        }
    }
}
