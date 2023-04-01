using UnityEngine;

public class Bunker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Invader"))
        {
            gameObject.SetActive(false);
            Destroy (gameObject);
        }
    }
}
