using System.Collections;
using UnityEngine;

public class Can : MonoBehaviour
{
    public GameObject piece;

    public GameObject crushed;

    public float speed = 2f;

    public Vector3 spawnPosition;

    public Collider spawnableArea;

    private Movement movement;

    private void Awake()
    {
        movement = FindAnyObjectByType<Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crasher") && movement.crushable)
        {
            StartCoroutine(Crushed());
        }
    }

    private void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * speed;
    }

    private IEnumerator Crushed()
    {
        piece.SetActive(false);
        crushed.SetActive(true);

        speed = .25f;

        yield return new WaitForSeconds(2f);

        ReUse();
        StopCoroutine(Crushed());
    }

    private void ReUse()
    {
        transform.position = spawnPosition;

        piece.SetActive(true);
        crushed.SetActive(false);

        speed = 1;
    }

    private void AdjustRandomArea()
    {
    }
}
