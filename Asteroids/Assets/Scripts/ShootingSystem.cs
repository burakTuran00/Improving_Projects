using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public Bullet bulletPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet bullet =
            Instantiate(bulletPrefab, transform.position, transform.rotation);

        bullet.Project(transform.up);
    }
}
