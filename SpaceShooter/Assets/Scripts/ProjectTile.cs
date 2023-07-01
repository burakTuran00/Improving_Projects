using TMPro;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    public GameObject laser;

    public Transform fromShoot;

    public int ammo = 30;

    public TextMeshProUGUI ammoText;

    private bool shotable => ammo > 0;

    private AudioSource soundEffect;

    public AudioClip laserEffect;

    public AudioClip loseEffect;

    public AudioClip powerUpEffect;

    private void Awake()
    {
        soundEffect = GetComponent<AudioSource>();
        soundEffect.clip = laserEffect;
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && shotable)
        {
            GameObject l =
                Instantiate(laser, fromShoot.position, Quaternion.identity);

            soundEffect.clip = laserEffect;
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

    public void Lose()
    {
        soundEffect.clip = loseEffect;
        soundEffect.Play();
    }

    public void PowerUpOfEffect()
    {
        soundEffect.clip = powerUpEffect;
        soundEffect.Play();
    }
}
