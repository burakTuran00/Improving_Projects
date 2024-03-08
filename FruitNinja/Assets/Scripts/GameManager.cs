using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.UI;

public  class GameManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private Image fadeImage;
    [SerializeField] private Text scoreText;
    [SerializeField] private Blade blade;
    [SerializeField] private Spawner spawner;
    private int score = 0;
    public string sentence{ get; set;}
    public event Action<char> OnCutLetter;
    [SerializeField] private List<string> tasks;
    private int taskIndex = 0;
    #endregion
    private void Start()
    {
        StartGame();
    }
    
    public void IncreaseScor(int point)
    {
        score += point;
        scoreText.text = score.ToString("00000");
    }

    public void StartGame()
    {
        Time.timeScale = 1f;

        blade.enabled = true;
        spawner.enabled = true;

        score = 0;
        scoreText.text = tasks[taskIndex].ToUpper().ToString();

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

        if(sentence == tasks[taskIndex].ToUpper())
        {
            taskIndex++;
            sentence = "";
            Debug.Log("Correct");
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
}
