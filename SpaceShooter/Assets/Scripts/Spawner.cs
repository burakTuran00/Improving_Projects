using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float spawnRate;

    public GameObject spawnableObject;

    public int spawnableAre = 9;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, 1f);
    }

    private void Spawn()
    {
        int randPos = Random.Range(-spawnableAre, spawnableAre);
        transform.position =
            new Vector3(randPos, transform.position.y, transform.position.z);

        GameObject e =
            Instantiate(spawnableObject, transform.position, Quaternion.identity);
    }
}
