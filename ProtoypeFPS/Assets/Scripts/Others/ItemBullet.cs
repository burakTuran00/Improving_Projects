using UnityEngine;

public class ItemBullet : MonoBehaviour
{
    public int amountAmmo = 30;

    public AmmoSystem ammoSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ammoSystem == null)
            {
                return;
            }

            ammoSystem.IncreaseAmmo (amountAmmo);
            this.gameObject.SetActive(false);
        }
    }
}
