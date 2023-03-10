using UnityEngine;

public class FollowingCam : MonoBehaviour
{
    public GameObject driver;

    private void Update()
    {
        transform.position =
            driver.transform.position + new Vector3(0f, 0f, -1.0f);
    }
}
