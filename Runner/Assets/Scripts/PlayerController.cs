using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;

    public float xSpeed = 1.0f;

    public float limitx;

    private void Update()
    {
        SwipeCheck();
    }

    void SwipeCheck()
    {
        float newX = 0;
        float touchXDelta = 0;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitx, limitx);

        Vector3 newPosition;
        newPosition.x = newX;
        newPosition.y = transform.position.y;
        newPosition.z = transform.position.z + runningSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
}
