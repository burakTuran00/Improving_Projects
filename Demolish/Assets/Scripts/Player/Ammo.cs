using TMPro;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public TextMeshProUGUI ammoText;

    private Shooting shooting;

    public int ammoAmount = 30;

    private void Awake()
    {
        shooting = GetComponent<Shooting>();
    }

    public void DecreaseAmmo()
    {
        ammoAmount--;
        ammoText.text = ammoAmount.ToString();

        if (ammoAmount <= 0)
        {
            shooting.enabled = false;

            ammoAmount = 0;
            ammoText.text = ammoAmount.ToString();
        }
    }

    public void IncreaseAmmo(int increaseAmount)
    {
        ammoAmount += increaseAmount;
        ammoText.text = ammoAmount.ToString();

        shooting.enabled = true;
    }
}
