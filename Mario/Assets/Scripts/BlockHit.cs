using UnityEngine;

public class BlockHit : MonoBehaviour
{
    public int maxHits = -1;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.transform.DotTest(transform, Vector2.up))
            {
                Hit();
            }
        }
    }

    private void Hit()
    {

    }
}
