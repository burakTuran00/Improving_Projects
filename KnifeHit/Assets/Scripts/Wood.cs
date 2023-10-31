using Unity.Mathematics;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float increaseForce;

    private void Update()
    {
        transform.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime);
    }

    public void IncreaseSpeed()
    {
        rotateSpeed *= increaseForce;
        rotateSpeed = Mathf.CeilToInt(rotateSpeed);
    }
}
