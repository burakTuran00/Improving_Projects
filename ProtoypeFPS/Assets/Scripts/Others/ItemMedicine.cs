using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMedicine : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public int amountIncreaseHealth = 35;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerHealth == null)
            {
                return;
            }

            playerHealth.IncreaseHealth(amountIncreaseHealth);
            this.gameObject.SetActive(false);
        }
    }
}
