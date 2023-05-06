using UnityEngine;

public class Health : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public int amountHealth = 30;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeHealth (amountHealth);
            Destroy(this.gameObject);
        }
    }
}
