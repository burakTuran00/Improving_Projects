using System.Collections;
using UnityEngine;

public class Combo : MonoBehaviour
{
    // Player mission will be here.

    private Collider spawnArea;

    public GameObject[] items;

    public GameObject[] comboArray;

    private int comboCounter = 0;

    private int size;
    [Header("Time Settings")]
    public float minSpawnDelay = 2;

    public float maxSpawnDelay = 5f;
    public float minAngle = -15f;

    public float maxAngle = 15f;

    public float minForce = 18f;

    public float maxForce = 22f;

    public float maxLifeTime = 5f;
    
    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
        
        comboArray = new GameObject[getRandomSize()];

        getRandomItem();

        foreach (GameObject comboItem in comboArray)
        {
            comboItem.tag = "Combo";
            comboItem.AddComponent<ComboItem>(); // add ComboItem script to adjust.
        }

        Debug.Log (size);

        
    }

    private void Start() {
        StartCoroutine(Spawn());
    }

    private int getRandomSize()
    {
        size = Random.Range(3, 6);
        return size;
    }

    private void getRandomItem()
    {
        int randomItemIndex = Random.Range(0, items.Length);

        for (int i = 0; i < comboArray.Length; i++)
        {
            comboArray[i] = items[randomItemIndex];
        }
    }

    private void resetCombo()
    {
        //todo: combo can use again.
        comboCounter = 0;
    }

    private IEnumerator Spawn()
    {
       

        yield return new WaitForSeconds(Random.Range(minSpawnDelay,maxSpawnDelay));

        while(enabled)
        {
            comboArray = new GameObject[getRandomSize()];

            getRandomItem();

            foreach (GameObject comboItem in comboArray)
            {
                comboItem.tag = "Combo";
                comboItem.AddComponent<ComboItem>(); // add ComboItem script to adjust.
            }

            for (int i = 0; i < comboArray.Length; i++)
            {
                //todo: create of combo array
                Vector3 position = new Vector3();
                position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
                position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

                Quaternion rotation = Quaternion.Euler(0f,0f, Random.Range(minAngle,maxAngle));

                GameObject comboObject = Instantiate(comboArray[i], position,rotation);
                Destroy(comboObject,maxLifeTime);

                float force = Random.Range(minForce,maxForce);  
            
                Rigidbody fruitRb = comboObject.GetComponent<Rigidbody>();
                fruitRb.AddForce(comboObject.transform.up * force, ForceMode.Impulse);
            }

            if(comboCounter >= comboArray.Length)
            {
                //todo: if player cuts a tag of combo, then increase comboCounter
                break;
                //StopAllCoroutines();
            }

            yield return new WaitForSeconds(Random.Range(minSpawnDelay,maxSpawnDelay));
        }
    }
}
