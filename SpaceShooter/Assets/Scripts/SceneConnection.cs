using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneConnection : MonoBehaviour
{
    public void ToPlay()
    {
        SceneManager.LoadScene(0);
    }
}
