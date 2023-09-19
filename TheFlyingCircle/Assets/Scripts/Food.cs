using System.Threading;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollisionArea"))
        {
            gameObject.SetActive(false);
        }
    }
}
