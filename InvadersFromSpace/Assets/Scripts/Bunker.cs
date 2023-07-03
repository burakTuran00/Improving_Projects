using UnityEngine;

public class Bunker : MonoBehaviour
{
    private new BoxCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            collider.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
