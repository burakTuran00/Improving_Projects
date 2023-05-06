using UnityEngine;
using System.Collections.Generic;
public class Shooting : MonoBehaviour
{
    public Camera FPS_cam;

    public float range = 50f;
    
    public int weaponDamage = 30;


    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(FPS_cam.transform.position,FPS_cam.transform.forward,out hit, range))
            {
                ZombieHealth zombiHealth = hit.transform.GetComponent<ZombieHealth>();
                if (zombiHealth == null)
                {
                    return;
                }
                zombiHealth.TakeDamageZombie(weaponDamage);
            }
            else
            {
                return;
            }

        }
    }

}