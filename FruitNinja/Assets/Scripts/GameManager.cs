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
    private string findenWordText;
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

        if(wordListLoader.BinarySearch(wordListLoader.words, sentence))
        {
            subList.Clear();
            subList = wordListLoader.GetAllSubstrings(sentence);

            foreach(string subword in subList)
            {
                if (wordListLoader.BinarySearch(wordListLoader.words, subword) || wordListLoader.BinarySearch(wordListLoader.findedWords, subword))
                {
                    totalAmountOfTimeToAdd += Mathf.FloorToInt(subword.Length); // todo: find a proper scor calculation.
                }
            }

            wordListLoader.RemoveAtSentence(sentence);
            wordListLoader.AddFindedWord(sentence);

            timer.getMoreTime(totalAmountOfTimeToAdd);

            totalAmountOfTimeToAdd = 0;
            sentence = "";
        }

        uIManager.SetWordTextColor((wordListLoader.BinarySearch(wordListLoader.findedWords, sentence)) ? Color.yellow : Color.white);
        
        if(sentence.Length > 10)
        {
            GetRidOfSentence();
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

        foreach(string sentence in wordListLoader.findedWords)
        {
            findenWordText = sentence + "\n";
        }
        
        uIManager.SetFindedText(findenWordText);
        Time.timeScale = 0f;
    }
}
