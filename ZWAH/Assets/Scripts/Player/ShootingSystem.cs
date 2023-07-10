using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    private Ammo ammoSystem;

    [Header("Weapon Settings")]
    public Camera Cam;

    public float range = 50.0f;

    public int weoponDamage = 30;

    [Header("Shoot Effect")]
    public ParticleSystem shootEffect;

    private void Awake() 
    {
        ammoSystem = GetComponent<Ammo>();    
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
                Debug.Log("+");
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
    }
}
