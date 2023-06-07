using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform cameraTarget;

    public float Speed = 1.0f;

    public Vector3 dist;

    public Transform lookTarget;

    private void LateUpdate()
    {
        Vector3 dPos = cameraTarget.position + dist;

        Vector3 sPos =
            Vector3.Lerp(transform.position, dPos, Speed * Time.deltaTime);

        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }
}
