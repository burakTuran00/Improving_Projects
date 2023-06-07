using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed = 1.0f;

    private void Update()
    {
        /* Vector3 newPosition =
            new Vector3(transform.position.x,
                transform.position.y,
                transform.position.z + runningSpeed * Time.deltaTime);*/
        //transform.position = newPosition;
        
        transform.position += Vector3.forward * runningSpeed * Time.deltaTime;
    }
}
