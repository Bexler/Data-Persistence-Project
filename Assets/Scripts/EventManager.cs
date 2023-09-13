using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public static EventManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public event Action OnGameStart;

    public event Action OnGameOver;

    public event Action<int> OnScoreUpdate;


    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public void ScoreUpdate(int score)
    {
        OnScoreUpdate?.Invoke(score);
    }

    public void GameStart()
    {
        OnGameStart?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
