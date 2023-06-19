using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public int score;

    private Vector3 startPosition = new Vector3(0f, 0.25f, -13f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("FinishLine"))
        {
            //todo
            FindObjectOfType<PlayerController>().isRunning = false;
            GetComponentInChildren<Animator>().SetTrigger("Idle");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            transform.position = startPosition;
        }
    }

    public void AddCoin()
    {
        score++;
    }
}
