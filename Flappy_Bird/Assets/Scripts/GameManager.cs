using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int score;
    public Text score_Text;
    public Button play_Button;
    public Image GmOver_Image;
    public Player player;



    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }
    public void Play()
    {
        score = 0;
        score_Text.text = score.ToString();

        play_Button.transform.localScale = new Vector2(0, 0);
        GmOver_Image.enabled = false; 

        Time.timeScale = 1f;
        player.enabled = true; 
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        
    }
    public void IncreaseScore()
    {
        score++;
        score_Text.text = score.ToString();
        
    }

    public void GameOver()
    {
        GmOver_Image.enabled = true;
        play_Button.enabled = true;
        play_Button.transform.localScale = new Vector2(1,1);
        Pause();
        
    }
}
