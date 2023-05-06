using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Ammo ammo;

    public int amountAmmo = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ammo.IncreaseAmmo(amountAmmo);
            Destroy(this.gameObject)
        }
    }
}
