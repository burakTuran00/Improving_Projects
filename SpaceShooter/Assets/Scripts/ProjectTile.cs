using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    public GameObject laser;

    public Transform fromShoot;

    public float laserDelay = 1.0f;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject l =
                Instantiate(laser, fromShoot.position, Quaternion.identity);
            Destroy (l, laserDelay);
        }
    }
}
