using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text wordText;

    public void SetWordText(string sentence)
    {
        wordText.text = sentence.ToUpper().ToString();
    }
}
