using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.forward , -rotateSpeed * Time.deltaTime);
    }
}
