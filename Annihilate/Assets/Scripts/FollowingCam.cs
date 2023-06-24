using UnityEngine;

public class FollowingCam : MonoBehaviour
{
    public Transform player;

    public float speed = 1.0f;

    public Vector3 Dist;

    public Transform finishLine;

    private void LateUpdate()
    {
        Vector3 distancePosition = player.position + Dist;
        transform.position = distancePosition;
        transform.LookAt(finishLine.position);
    }
}
