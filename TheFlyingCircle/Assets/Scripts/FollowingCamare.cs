using UnityEngine;

public class FollowingCamare : MonoBehaviour
{
    public Transform player;

    public float speed = 1.0f;

    public Vector3 Dist;

    private void LateUpdate()
    {
        Vector3 distancePosition = player.position + Dist;
        transform.position = distancePosition;
    }
}
