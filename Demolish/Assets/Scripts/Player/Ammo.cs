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
            ammoAmount = 0;
            ammoText.text = ammoAmount.ToString();

            shooting.enabled = false;
        }
    }

    public void IncreaseAmmo()
    {
        
    }
}
