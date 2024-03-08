using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables
    [SerializeField] private Collider spawnArea;
    [SerializeField] private GameObject[] letterPrefabs;
    [SerializeField] private float minSpawnDelay = 0.25f;
    [SerializeField] private float maxSpawnDelay = 1f;
    [SerializeField] private float minAngle = -15f;
    [SerializeField] private float maxAngle = 15f;
    [SerializeField] private float minForce = 18f;
    [SerializeField] private float maxForce = 22f;
    [SerializeField] private float maxLifeTime = 8f;
    private bool condition = true;
    #endregion

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1f);

        while(condition)
        {
            GameObject prefab = letterPrefabs[Random.Range(0, letterPrefabs.Length)];

            Vector3 position = new Vector3();
            position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f,0f, Random.Range(minAngle,maxAngle));

            GameObject letter = Instantiate(prefab, position, Quaternion.identity); 
            letter.transform.SetParent(transform);
            letter.transform.RotateAround(letter.transform.position, Vector3.left , 90f);            

            Destroy(letter, maxLifeTime);

            float force = Random.Range(minForce,maxForce);  
            
            Rigidbody fruitRb = letter.GetComponent<Rigidbody>();
            fruitRb.AddForce(letter.transform.forward * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minSpawnDelay,maxSpawnDelay));
        }
    }

    public int getLettersCount()
    {
        return letterPrefabs.Length;
    }

    public void StopSpawner()
    {
        condition = false;
        StopCoroutine(Spawn());
    }
}