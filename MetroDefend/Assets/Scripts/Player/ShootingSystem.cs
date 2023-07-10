using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    private AmmoSystem ammoSystem;

    [Header("Weapon Settings")]
    public Camera Cam;

    public float range = 50.0f;

    public int weoponDamage = 30;

    [Header("Shoot Effect")]
    public ParticleSystem shootEffect;

    [Header("Sound Effect")]

    public AudioSource audioSource;

    private void Awake() 
    {
        ammoSystem = GetComponent<AmmoSystem>();    
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootEffectPlay();
            ammoSystem.AdjustAmmo();

            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position,Cam.transform.forward,out hit,range))
            {
               //todo
            }
            else
            {
                return;
            }
        }
    }

    private void ShootEffectPlay()
    {
        shootEffect.Play();
        audioSource.Play();
    }
}