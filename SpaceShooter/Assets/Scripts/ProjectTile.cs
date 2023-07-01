using TMPro;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    public GameObject laser;

    public Transform fromShoot;

    public float laserDelay = 1.0f;

    private int ammo = 30;

    public TextMeshProUGUI ammoText;

    private bool shotable => ammo > 0;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && shotable)
        {
            GameObject l =
                Instantiate(laser, fromShoot.position, Quaternion.identity);
            Destroy (l, laserDelay);

            ammo--;
            ammoText.text = "x" + ammo.ToString();

            if (ammo < 1)
            {
                ammo = 0;
            }
        }
    }
}
