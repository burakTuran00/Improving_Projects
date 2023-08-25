using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int ammountHealt = 15;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();
            ph.IncreaseHealth (ammountHealt);

            this.gameObject.SetActive(false);
        }
    }
}
