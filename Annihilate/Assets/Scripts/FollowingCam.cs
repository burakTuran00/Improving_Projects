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
        Vector3 camPosition = Vector3.Lerp(transform.position,distancePosition,speed*Time.deltaTime);
        transform.position = camPosition;
        transform.LookAt(finishLine.position);
    }
}
