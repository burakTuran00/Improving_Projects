using UnityEngine;
using UnityEngine.UI;

public class Roteta_Main : MonoBehaviour
{
    public float eulerSpeed = 50f;

    private int score = 0;

    public Text scoreText;

    private void Awake()
    {
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f) * eulerSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Stick"))
        {
            other.transform.SetParent(this.transform);
            score++;
            scoreText.text = score.ToString();
        }
    }
}
