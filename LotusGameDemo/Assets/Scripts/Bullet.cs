using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float force;

    [SerializeField]
    private float remian;

    private void OnEnable()
    {
        Destroy(this.gameObject, remian);
    }

    private void Update()
    {
        transform.position += Vector3.forward * force * Time.deltaTime;
    }
}
