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

            Frogger frogger = other.GetComponent<Frogger>();
            frogger.gameObject.SetActive(false);
            frogger.Invoke(nameof(frogger.Respawn), 1f);
        }
    }
}
