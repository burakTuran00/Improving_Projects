using System.Collections;
using System.Threading;
using UnityEngine;

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
            float foodRadius = other.GetComponent<SphereCollider>().radius;

            if (other.gameObject != null)
            {
                if (playerCollider.radius > foodRadius)
                {
                    Eat(other.gameObject);
                }
                else
                {
                    StopAllCoroutines();
                    return; // pass the food
                }
            }
            else
            {
                return;
            }
        }
    }

    public void Eat(GameObject food)
    {
        Thread.Sleep(200);
        food.SetActive(false);

        Thread.Sleep(100);
        Grow (food);
    }

    public void Grow(GameObject food)
    {
        float growthValue = food.GetComponent<SphereCollider>().radius;

        transform.localScale += (Vector3.one * growthValue);
    }
}
