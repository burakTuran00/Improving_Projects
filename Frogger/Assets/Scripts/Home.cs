using UnityEngine;

public class Home : MonoBehaviour
{
    public GameObject homeFrog;

    private void OnEnable()
    {
        homeFrog.SetActive(true);
    }

    private void OnDisable()
    {
        homeFrog.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enabled = true;
            FindObjectOfType<GameManager>().HomeOccupied();
        }
    }
}
