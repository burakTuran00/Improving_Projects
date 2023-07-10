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
}
