using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public int score;

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
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //todo
        }
    }

    public void AddCoin()
    {
        score++;
    }
}
