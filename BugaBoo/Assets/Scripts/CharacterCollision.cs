using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCollision : MonoBehaviour
{
    private float trapDamage = 10f;

    private float trapForce = 150f;

    public Text appleText;

    private int appleCounter=0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Trap"))
        {
            FindObjectOfType<Health>().TakeDamage(trapDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Apple"))
        {
            appleCounter++;
            appleText.text = "x" + appleCounter.ToString();

            Destroy(other.gameObject);
        }
       
    }
}
