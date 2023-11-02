using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private Fruit[] fruits;

    private int fruitsNumber;

    [SerializeField]
    private Thrower thrower;

    [SerializeField]
    private float delay;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private TextMeshProUGUI sliderText;

    private float remainValue;

    private void Awake()
    {
        fruitsNumber = fruits.Length;
        remainValue = 100 / fruitsNumber;
        remainValue = Mathf.Ceil(remainValue);
    }

    private void Start()
    {
        if (remainValue * fruitsNumber != 100)
        {
            remainValue += 1;
        }
    }

    public void DecreaseFruit()
    {
        fruitsNumber--;

        if (fruitsNumber >= 0)
        {
            if (slider.value >= 95)
            {
                slider.value = 100;
            }

            slider.value += remainValue;
            sliderText.text = "%" + slider.value.ToString();
        }

        if (fruitsNumber < 1 && thrower.GetIndex() >= 0)
        {
            NextLevel();
        }
    }

    public void IsLevelEnd()
    {
        if (fruitsNumber > 0 && thrower.GetIndex() < 1)
        {
            RestartLevel();
        }
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            currentSceneIndex = 0;
            nextSceneIndex = 0;
        }

        StartCoroutine(LoadScene(nextSceneIndex, delay));
    }

    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadScene(currentSceneIndex, delay * 1.5f));
    }

    private IEnumerator LoadScene(int sceneIndex, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene (sceneIndex);
    }
}
