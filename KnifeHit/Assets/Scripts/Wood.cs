using UnityEngine;
using Unity.Mathematics;

public class Wood : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float increaseForce;

    [SerializeField]
    private AudioSource audioSource;

    private void Update()
    {
        transform.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime);
    }

    public void IncreaseSpeed()
    {
        rotateSpeed *= increaseForce;
        rotateSpeed = Mathf.CeilToInt(rotateSpeed);
    }

    public void CallHitVoice()
    {
        audioSource.Play();
    }
}
