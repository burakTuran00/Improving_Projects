using TMPro;
using UnityEngine;

public class AmmoSystem : MonoBehaviour
{
    private ShootingSystem shootingSystem;

    [Header("Ammo Settings")]
    public TextMeshProUGUI ammoText;

    public int ammo = 30;

    private void Awake()
    {
        shootingSystem = GetComponent<ShootingSystem>();
    }

    public void AdjustAmmo()
    {
        ammo--;

        if (ammo <= 0)
        {
            ammo = 0;
            shootingSystem.enabled = false;
        }

        ammoText.text = "x" + ammo.ToString();
    }

    public void IncreaseAmmo(int amount)
    {
        ammo += amount;

        if (amount >= 100)
        {
            ammo = 100;
        }

        ammoText.text = "x" + ammo.ToString();
        shootingSystem.enabled = true;
    }

    public int GetAmmo()
    {
        return ammo;
    }
}
