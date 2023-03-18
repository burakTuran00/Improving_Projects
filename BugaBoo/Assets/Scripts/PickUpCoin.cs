using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public AudioClip sfx;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sfx, Camera.main.transform.position);
            Destroy (gameObject);
        }
    }
}
