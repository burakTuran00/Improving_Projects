using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float spawnRate;

    public GameObject enemy;

    public int spawnableAre = 9;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, 1f);
    }

    private void Spawn()
    {
        int randPos = Random.Range(-spawnableAre, spawnableAre);
        

        GameObject e =
            Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
