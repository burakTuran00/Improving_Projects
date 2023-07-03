using UnityEngine;
using UnityEngine.SceneManagement;

public class Missile : MonoBehaviour
{
    public float speed = 1.0f;

    public Vector3 direction = Vector3.down;

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy (gameObject);

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
