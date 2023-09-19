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
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.GetComponent<Food>().PlayEatAudio();
            transform.localScale *= 1.025f;
        }
    }
}
