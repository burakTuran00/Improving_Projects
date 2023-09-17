using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 direction;

    [SerializeField]
    float speed = 1.0f;

    [SerializeField]
    float sideSpeed = 1.0f;

    private void Update()
    {
        playerMove();
    }

    private void playerMove()
    {
        direction.x = Mathf.Clamp(direction.x, -3f, 3f);

        transform.position += Vector3.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.zero;
        }

        transform.position += direction * sideSpeed * Time.deltaTime;
    }
}
