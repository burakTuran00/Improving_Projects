using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public float speed = 5.0f;

    private Vector3 direction;

    public float delayTime = 1.0f;

    public ParticleSystem crashAffect;

    public Parallax[] parallaxes;

    public Spawner spawner;

    private bool doDrive = true;

    private void Awake()
    {
        doDrive = true;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (doDrive)
        {
            direction.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            direction.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            transform.position += direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BotCar"))
        {
            Bot bot = other.gameObject.GetComponent<Bot>();
            bot.doDrive = false;

            doDrive = false;

            foreach (Parallax p in parallaxes)
            {
                p.waySpeed = 0;
            }

            spawner.enabled = false;

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
