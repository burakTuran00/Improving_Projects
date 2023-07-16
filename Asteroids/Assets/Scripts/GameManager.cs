using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player;

    public int lives = 3;

    public float respanwRate = 1.75f;

    public float collisionWaitingTime = 3.0f;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    public void PlayerDied()
    {
        lives--;

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respanwRate);
        }
    }

    private void Respawn()
    {
        player.transform.position = Vector3.zero;
        player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollision");
        player.gameObject.SetActive(true);

        Invoke(nameof(TurnOnCollision), collisionWaitingTime);
    }

    private void TurnOnCollision()
    {
        player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
    }
}
