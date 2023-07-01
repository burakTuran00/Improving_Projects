using TMPro;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    public GameObject laser;

    public Transform fromShoot;

    private int ammo = 30;

    public TextMeshProUGUI ammoText;

    private bool shotable => ammo > 0;

    private AudioSource soundEffect;

    public AudioClip ammoEffect;

    public AudioClip loseEffect;

    private void Awake()
    {
        soundEffect = GetComponent<AudioSource>();
        soundEffect.clip = ammoEffect;
    }

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

            soundEffect.Play();

            DecreaseAmmo();
        }
    }

    private void DecreaseAmmo()
    {
        ammo--;
        ammoText.text = "x" + ammo.ToString();

        if (ammo < 1)
        {
            ammo = 0;
        }
    }
}
