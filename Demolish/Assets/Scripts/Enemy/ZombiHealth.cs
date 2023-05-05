using UnityEngine;

public class ZombiHealth : MonoBehaviour
{
    private int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DieZombie();
        }
    }

    private void DieZombie()
    {
        Destroy(this.gameObject);
    }
}
