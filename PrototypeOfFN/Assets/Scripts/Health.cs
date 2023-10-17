using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image[] healthImages;

    public int health = 3;

    public void TakeHealth()
    {
        health--;
        healthImages[health].color = Color.black;

        if(health <= 0)
        {
            Debug.Log("Restart");
            //todo
        }
    }
}
