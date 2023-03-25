using UnityEngine;

public class PlayerDetectCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Spike"))
        {
            Debug.Log("+");
        }
    }
}
