using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;

    public Button restartButton;

    private Vector2 current_Pos;

    private int score = 0;

    private void Awake()
    {
        current_Pos = restartButton.transform.position;
        scoreText.text = score.ToString();
        restartButton.transform.position = new Vector2(2000f, 2000f);
        restartButton.interactable = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void Restart()
    {
        GameObject[] gm = GameObject.FindGameObjectsWithTag("Stick");

        foreach (GameObject item in gm)
        {
            Destroy (item);
        }

        score = 0;
        scoreText.text = score.ToString();
        Time.timeScale = 1f;
        restartButton.transform.position = new Vector2(2000f, 2000f);
        restartButton.interactable = false;
    }

    public void ResButPos()
    {
        restartButton.transform.position = current_Pos; //new Vector2(540f, 500f);
        restartButton.interactable = true;
    }
}
