using UnityEngine;

public class Bunkers : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Invader"))
        {
            gameObject.SetActive(false);
        }
    }
}
