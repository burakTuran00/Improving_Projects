using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject prefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject gm =
                Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
