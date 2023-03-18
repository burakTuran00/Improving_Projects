using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    private void Awake()
    {
        int numberScenePersist = FindObjectsOfType<ScenePersist>().Length;

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
