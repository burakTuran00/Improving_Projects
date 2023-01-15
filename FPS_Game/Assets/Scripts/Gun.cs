using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;

    public float range = 100f;

    public Camera cross;
   // public ParticleSystem effect;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
       // effect.Play();
        RaycastHit hit;
        if (Physics.Raycast(cross.transform.position, cross.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name.ToString());
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
