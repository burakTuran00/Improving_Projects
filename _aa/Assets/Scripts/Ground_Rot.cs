using UnityEngine;

public class Ground_Rot : MonoBehaviour
{
    public float eulerSpeed = 50f;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f) * eulerSpeed * Time.deltaTime);
    }
}
