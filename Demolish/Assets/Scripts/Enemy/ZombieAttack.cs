using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public PlayerHealth target;

    public int zombieDamage = 15;

    private void Awake()
    {
    }

    public void ZombieAttactEvent()
    {
        if (target == null)
        {
            return;
        }

        target.TakeDamagePlayer (zombieDamage);
    }
}
