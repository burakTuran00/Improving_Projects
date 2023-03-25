using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool wasCollected = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Coin") && !wasCollected)
        {
            wasCollected = true;
            Destroy(other.gameObject);
        }
        else if (other.transform.CompareTag("Spike"))
        {
        }
    }
}
