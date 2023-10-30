using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public Transform spawnPosition;

    private void Spawn()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject g = Instantiate(prefab, transform.position , Quaternion.identity);
        }
    }    
}
