using UnityEngine;
using System.Collections.Generic;
public class Shooting : MonoBehaviour
{
    public Camera FPS_cam;

    public float range = 50f;
    
    public int weaponDamage = 25;


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
                ZombiHealth zombiHealth = hit.transform.GetComponent<ZombiHealth>();
                if (zombiHealth == null)
                {
                    return;
                }
                zombiHealth.TakeDamage(weaponDamage);
            }
            else
            {
                return;
            }

        }
    }

}
