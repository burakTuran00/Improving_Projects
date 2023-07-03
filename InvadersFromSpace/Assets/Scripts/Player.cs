using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;

    private Vector3 direction;

    public bool laserActive { get; set; }

    public GameObject laser;

    private void Update()
    {
        Movement();
        Shoot();
    }

    private void Movement()
    {
        direction.x = Input.GetAxis("Horizontal");

        transform.position += direction * speed * Time.deltaTime;
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!laserActive)
            {
                GameObject l =
                    Instantiate(laser, transform.position, Quaternion.identity);
                laserActive = true;
            }
        }
    }
}
