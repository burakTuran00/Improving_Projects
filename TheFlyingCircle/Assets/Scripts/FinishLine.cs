using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().NextLevel();
            FindAnyObjectByType<Movement>().movable = false;
        }
    }
}
