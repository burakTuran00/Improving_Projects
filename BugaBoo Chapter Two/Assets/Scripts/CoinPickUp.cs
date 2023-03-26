using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    private bool wasPick = false;

    public AudioClip coinSFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") && !wasPick)
        {
            wasPick = true;
            AudioSource
                .PlayClipAtPoint(coinSFX, Camera.main.transform.position);
            Destroy (gameObject);
        }
    }
}
