using UnityEngine;

public class Health : MonoBehaviour
{
    private int MaxHealth = 100;

    private int currentHealth;

    public int damage = 15;

    private void Awake()
    {
        currentHealth = MaxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth -= damage;
            Debug.Log(currentHealth.ToString());
            if (currentHealth <= 0)
            {
                Debug.Log("Died");
            }
        }
    }
}
