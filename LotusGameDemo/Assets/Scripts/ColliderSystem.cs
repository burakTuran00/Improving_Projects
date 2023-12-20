using UnityEngine;

public class ColliderSystem : MonoBehaviour
{
    private GameObject gun;

    private void Awake()
    {
        gun = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            other.transform.SetParent(gun.transform);
        }
    }
}
