using UnityEngine;

public class CollisionWith : MonoBehaviour
{
    private bool hasPackage = false;

    [SerializeField]
    float boostSpeed = 20f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Take Damage
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Package") && !hasPackage)
        {
            //Take package
            hasPackage = true;
            Destroy(other.gameObject);
        }
        else if (other.transform.CompareTag("Customer") && hasPackage)
        {
            //Give customer
            hasPackage = false;
            Destroy(other.gameObject);
        }
        else if (other.transform.CompareTag("Boost"))
        {
            FindObjectOfType<Driver>().BoostSpeed(boostSpeed);
            Destroy(other.gameObject);
        }
    }
}
