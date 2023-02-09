using UnityEngine;

public class Stic_Movement : MonoBehaviour
{
    public float speed = 25f;

    private void Start()
    {
        InvokeRepeating(nameof(Moving), .1f, .01f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Main"))
        {
            Debug.Log("hit");
            CancelInvoke(nameof(Moving));
        }
        else if (other.transform.CompareTag("Stick"))
        {
            Time.timeScale = 0f;
        }
    }

    void Moving()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
