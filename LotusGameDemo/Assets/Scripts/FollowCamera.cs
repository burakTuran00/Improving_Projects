using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 dist;

    private void Update()
    {
        Vector3 distancePosition = target.position + dist;
        transform.position = distancePosition;
    }
}
