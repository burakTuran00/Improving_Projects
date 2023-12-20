using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Vector3 direciton;

    private new Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        ForwardMove();
        SideMovement();
    }

    private void SideMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            direciton = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direciton = Vector3.right;
        }
        else
        {
            direciton = Vector3.zero;
        }

        transform.position += direciton * speed * Time.deltaTime;
    }

    void ForwardMove()
    {
        this.transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            other.transform.SetParent(this.transform);
            ColliderSystem cs = other.GetComponent<ColliderSystem>();
        }
    }
}
