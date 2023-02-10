using UnityEngine;

public class Product : MonoBehaviour
{
    public GameObject prefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, new Vector2(0f, -3f), Quaternion.identity);
        }
    }
}
