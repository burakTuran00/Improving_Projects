using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Unity.VisualScripting.Dependencies.NCalc;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform spawnPosition;

    [SerializeField]
    private float spwanRate;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spwanRate, spwanRate);
    }

    private void Spawn()
    {
        GameObject b =
            Instantiate(bullet, spawnPosition.position, Quaternion.identity);
    }

    public void SetRate(bool isSum, float value)
    {
        if (isSum)
        {
            value /= 100;
            spwanRate -= value;
        }
        else
        {
            float newValue = Mathf.Pow(value, 2);
            newValue = Mathf.FloorToInt(newValue);
            newValue /= 100;
            spwanRate -= newValue;
        }
    }
}
