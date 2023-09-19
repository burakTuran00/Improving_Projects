using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public Camera finalCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Movement>().enabled = false;

            PlayerFinalStructure pfs = FindObjectOfType<PlayerFinalStructure>();
            pfs.enabled = true;
            pfs.isMovable = true;

            Camera.main.GetComponent<FollowingCamare>().enabled = false;

            Camera.main.transform.position = finalCam.transform.position;
            Camera.main.transform.rotation = finalCam.transform.rotation;
        }
    }
}
