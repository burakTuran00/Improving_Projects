using UnityEngine;

public class PickingCoin : MonoBehaviour
{
    public AudioClip coinSFX;

    private bool wasPicked = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            wasPicked = true;
            AudioSource
                .PlayClipAtPoint(coinSFX, Camera.main.transform.position);
            Destroy(this.gameObject);
        }
    }
}
