using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTransition : MonoBehaviour
{
    public int levelIndex;

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelIndex);

        //todo: do with text, get text and load the scene.
    }
}
