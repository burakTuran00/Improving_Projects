using UnityEngine;

public class GetCoin : MonoBehaviour
{
    public AudioClip coinSound;

    private bool wasPicked = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !wasPicked)
        {
            wasPicked = true;

            AudioSource
                .PlayClipAtPoint(coinSound, Camera.main.transform.position);
            Destroy (gameObject);
        }
    }
}
