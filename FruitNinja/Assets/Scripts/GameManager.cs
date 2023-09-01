using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;

    private int score = 0;

    private void Start()
    {
        NewGame();
    }

    public void IncreaseScor()
    {
        score++;
        scoreText.text = score.ToString("00000");
    }

    public void NewGame()
    {
        score = 0;
        scoreText.text = score.ToString("00000");
    }
}
