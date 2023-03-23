using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
