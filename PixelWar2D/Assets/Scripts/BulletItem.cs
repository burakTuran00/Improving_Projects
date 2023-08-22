using UnityEngine;

public class BulletItem : MonoBehaviour
{

    public int amountAmmo = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ShootingSystem shootingSystem = other.gameObject.GetComponent<ShootingSystem>();
            shootingSystem.TakeAmmo(amountAmmo);

            this.gameObject.SetActive(false);
        }
    }
}
