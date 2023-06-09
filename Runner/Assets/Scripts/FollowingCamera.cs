using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform target;

    public float Speed = 1.0f;

    public Vector3 dist;

    public Transform lookTarget;

    private void LateUpdate()
    {
        Vector3 distancePosition = target.position + dist;

        Vector3 camPosition =
            Vector3.Lerp(transform.position, distancePosition, Speed * Time.deltaTime);

        transform.position = distancePosition;
        transform.LookAt(lookTarget.position);
    }
}
