using UnityEngine;

public class Bot : MonoBehaviour
{
    public float carSpeed = 1.0f;

    public bool doDrive = true;

    private void Awake()
    {
        carSpeed = Random.Range(10f, 12f);
    }

    private void Update()
    {
        if (doDrive)
        {
            transform.position += Vector3.down * carSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestroyBlock"))
        {
            Destroy (gameObject);
        }
    }
}
