using TMPro;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int value;

    public char operaiton;

    public TextMeshPro text;

    private void Awake()
    {
        if (text != null)
        {
            text.text = operaiton.ToString() + value.ToString();
        }
    }
}
