using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Destroy (gameObject);
        }
    }
}
