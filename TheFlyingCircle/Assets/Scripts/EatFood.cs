using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;

public class EatFood : MonoBehaviour
{
    private SphereCollider playerCollider;

    private void Awake()
    {
        playerCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            transform.localScale *= 1.25f;
        }
    }
}
