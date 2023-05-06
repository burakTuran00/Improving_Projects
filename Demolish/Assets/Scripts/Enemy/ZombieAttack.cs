using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private PlayerHealth target;

    public int damage = 10;

    private void Awake()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null)
        {
            return;
        }

        target.PlayerTakeDamage(damage);
    }
}
