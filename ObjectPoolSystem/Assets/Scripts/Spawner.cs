using UnityEngine;

public class Spawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;    
    }

    private void Update()
    {
        objectPooler.SpawnFromPool("Tag", transform.position, Quaternion.identity);
    }
}