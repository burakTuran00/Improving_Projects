using System.Threading;
using UnityEngine;

public class Can : MonoBehaviour
{
    public GameObject piece;

    public GameObject crushed;

    public float speed = 2f;

    private void OnTriggerEnter(Collider other)
    {
        piece.SetActive(false);
        crushed.SetActive(true);

        speed = .5f;
    }

    private void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * speed;
    }
}
