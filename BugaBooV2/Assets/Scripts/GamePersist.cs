using UnityEngine;

public class GamePersist : MonoBehaviour
{
    private void Awake()
    {
        int numberScenePersist = FindObjectsOfType<GameManager>().Length;

        if (numberScenePersist > 1)
        {
            Destroy (gameObject);
        }
        else
        {
            DontDestroyOnLoad (gameObject);
        }
    }

    public void ResetScenePersist()
    {
        Destroy (gameObject);
    }
}
