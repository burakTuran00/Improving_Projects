using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log(health.ToString());
        if (health <= 0)
        {
            Destroy (gameObject);
        }
    }
}
