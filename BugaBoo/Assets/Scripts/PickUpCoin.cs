using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public AudioClip sfx;

    private int valueForPicking = 100;

    private bool wasCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().IncreaseScore(valueForPicking);
            AudioSource.PlayClipAtPoint(sfx, Camera.main.transform.position);
            Destroy (gameObject);
        }
    }
}
