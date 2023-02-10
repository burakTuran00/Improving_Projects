using UnityEngine;

public class Stick_Movement : MonoBehaviour
{
    public float speed = 40f;

    private Vector3 direction = Vector3.up;

    private void Awake()
    {
        InvokeRepeating(nameof(Moving), .1f, .01f);
    }

    private void Moving()
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Ground_Rot"))
        {
            // Score++
            CancelInvoke(nameof(Moving));
            this.transform.SetParent(other.transform);
            FindObjectOfType<GameManager>().IncreaseScore();
        }
        else if (other.transform.CompareTag("Stick"))
        {
            // GameOver
            Time.timeScale = 0f;
            FindObjectOfType<GameManager>().ResButPos();
        }
    }
}
