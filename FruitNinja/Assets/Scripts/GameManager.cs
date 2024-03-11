using System;
using System.Collections.Generic;
using UnityEngine;

public  class GameManager : MonoBehaviour
{
    public  event Action<char> OnSentenceAddedEvent;

    #region Variables
    //[SerializeField] private Text scoreText;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private Blade blade;
    [SerializeField] private Spawner spawner;
    [SerializeField] private Timer timer;
    [SerializeField] private WordListLoader wordListLoader;
    private int score = 0;
    public string sentence{ get; set;}
    private int currentSentenceScore;
    private List<string> subList;
    private int totalAmountOfTimeToAdd;
    #endregion

    #region  Singleton
    public static GameManager Instance;
    private void Awake() 
    {
        Instance = this;
    }
    
    #endregion
    private void Start()
    {
        StartGame();
    }
    private void Update() 
    {
        GameOver();   
    }
    
    public void StartGame()
    {
        subList = new List<string>();

        Time.timeScale = 1f;

        blade.enabled = true;
        spawner.enabled = true;

        score = 0;
    }

    public void AddSentence(char value)
    {   
        sentence += value;

        if(wordListLoader.BinarySearch(sentence))
        {
            subList.Clear();
            subList = wordListLoader.GetAllSubstrings(sentence);

            foreach(string subword in subList)
            {
                if (wordListLoader.BinarySearch(subword))
                {
                    totalAmountOfTimeToAdd += subword.Length;
                }
            }
            timer.getMoreTime(totalAmountOfTimeToAdd + 3);
            sentence = "";
        }
        

        if(sentence.Length > 10)
        {
            sentence = "";
        }

        uIManager.SetWordText(sentence);
        totalAmountOfTimeToAdd = 0;
    }
    public void GetRidOfSentence()
    {
        if(sentence != "")
        {
            sentence = "";
            
        }
        uIManager.SetWordText(sentence);
    }

    public void GameOver()
    {
        if(timer.getRemainingTime() > 0)
        {
            return;
        }

        Pooler.StopPooler();
    }
}
