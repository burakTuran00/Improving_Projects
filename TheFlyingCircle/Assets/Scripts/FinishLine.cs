using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public Camera finalCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Movement>().atFinal = true;

            Camera.main.GetComponent<FollowingCamare>().enabled = false;

            Camera.main.transform.position = finalCam.transform.position;
            Camera.main.transform.rotation = finalCam.transform.rotation;
        }
    }
}
