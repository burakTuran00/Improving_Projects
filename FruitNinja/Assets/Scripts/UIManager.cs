using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text wordText;
    [SerializeField] private TextMeshProUGUI findedWordsText;
    [SerializeField] private Image findenWordImage;

    public void SetWordText(string sentence)
    {
        wordText.text = sentence.ToUpper().ToString();
    }
    public void SetWordTextColor(Color color)
    {
        wordText.color = color;
    }
    public void SetFindedText(string sentence)
    {
        findenWordImage.gameObject.SetActive(true);
        findedWordsText.text = sentence.ToUpper().ToString();
    }
}
