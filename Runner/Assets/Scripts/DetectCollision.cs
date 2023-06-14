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
    }

    public void AddCoin()
    {
        score++;
    }
}
