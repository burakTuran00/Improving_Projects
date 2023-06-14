using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public int score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();

            other.gameObject.SetActive(false);
        }
    }

    public void AddCoin()
    {
        score++;
    }
}
