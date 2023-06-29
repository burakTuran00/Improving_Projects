using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cars;

    public float spawnRate = 2.0f;

    public float spawthenRate = 0.75f;

    public float min = -6.0f;

    public float max = 4.5f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawthenRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject c =
            Instantiate(SelectCar(), transform.position, Quaternion.identity);
        float ranPos = Random.Range(min, max);

        c.transform.position += Vector3.right * ranPos;
    }

    private GameObject SelectCar()
    {
        int index = Random.Range(0, 3);
        return cars[index];
    }
}
