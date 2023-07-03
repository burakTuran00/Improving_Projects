using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;

    private Vector3 direction;

    public GameObject laser;

    public Transform shootPoint;

    private void Update()
    {
        Movement();
        Shoot();
    }

    private void Movement()
    {
        direction.x = Input.GetAxis("Horizontal");

        transform.position += direction * speed * Time.deltaTime;
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            GameObject l =
                Instantiate(laser, shootPoint.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene (currentSceneIndex);
        }
    }
}
