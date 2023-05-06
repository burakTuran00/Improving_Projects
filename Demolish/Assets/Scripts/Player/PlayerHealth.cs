using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public void PlayerTakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        Destroy(this.gameObject);
    }

    public void TakeHealth(int healthKit)
    {
        health += healthKit;

        if (health >= 100)
        {
            health = 100;
        }
    }
}
