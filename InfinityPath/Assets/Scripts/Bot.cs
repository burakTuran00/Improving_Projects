using UnityEngine;

public class Bot : MonoBehaviour
{
    public float carSpeed = 8.0f;

    private void Update()
    {
        transform.position += Vector3.down * carSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestroyBlock"))
        {
            Destroy (gameObject);
        }
    }
}
