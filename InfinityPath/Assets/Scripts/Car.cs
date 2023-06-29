using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public float speed = 5.0f;

    private Vector3 direction;

    public float delayTime = 1.0f;

    public ParticleSystem crashAffect;

    public bool drivable = true;

    private void Awake()
    {
        drivable = true;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        direction.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        direction.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.position += direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BotCar"))
        {
            crashAffect.Play();
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
