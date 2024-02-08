using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following_Cam : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float camSpeed = 1.0f;

    [SerializeField]
    private Vector3 dist;

    private void LateUpdate()
    {
        Vector3 distancePosition = player.position + dist;
        Vector3 camPosition = Vector3.Lerp(transform.position, distancePosition, camSpeed * Time.deltaTime);
        transform.position = camPosition;
    }
}
