using UnityEngine;

public class Movement : MonoBehaviour
{
    private void Update()
    {
        this.transform.position += Vector3.forward;
    }
}
