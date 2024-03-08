using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.UI;

public  class GameManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private Text scoreText;
    [SerializeField] private Blade blade;
    [SerializeField] private Spawner spawner;
    [SerializeField] private Timer timer;
    [SerializeField] private WordListLoader wordListLoader;
    private int score = 0;
    public string sentence{ get; set;}
    public event Action<char> OnCutLetter;
    private int currentSentenceScore;
    private List<string> subList;
    private int totalAmountOfTimeToAdd;
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

        ClearScene();
    }

    private void ClearScene()
    {
        // it cannot be nessecary if pool will be build.
        Letter[] letters = FindObjectsOfType<Letter>();

        foreach (Letter letter in letters)
        {
            Destroy(letter.gameObject);
        }
    }

    public void DecreaseCerainTaskCount(char letterChar, int letterIndex)
    {
        if(letterChar < 0 || letterIndex > spawner.getLettersCount())
        {
            return;
        }

            // todo
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
            timer.getMoreTime(totalAmountOfTimeToAdd);
            sentence = "";
        }
        

        if(sentence.Length > 10)
        {
            sentence = "";
        }

        scoreText.text = sentence.ToString();
    }

    public void GetRidOfSentence()
    {
        if(sentence != "")
        {
            sentence = "";
            scoreText.text = sentence.ToUpper().ToString();
        }
        
    }

    public void GameOver()
    {
        if(timer.getRemainingTime() > 0)
        {
            return;
        }

        spawner.StopSpawner();
    }
}
