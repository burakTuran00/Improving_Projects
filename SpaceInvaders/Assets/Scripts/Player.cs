using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public ProjectTile laserPrefab;

    public float speed = 5.0f;

    private bool laserActive;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (
            other.gameObject.layer == LayerMask.NameToLayer("Invader") ||
            other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Shoot()
    {
        if (!laserActive)
        {
            ProjectTile projectTile =
                Instantiate(laserPrefab,
                transform.position,
                Quaternion.identity);
            projectTile.destroyed += LaserDestroyed;
            laserActive = true;
        }
    }

    public void LaserDestroyed()
    {
        laserActive = false;
    }
}
