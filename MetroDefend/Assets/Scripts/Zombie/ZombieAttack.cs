using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieAttack : MonoBehaviour
{
    public PlayerHealth target;

    public Image bloodImage;

    public float bloodImpactTime = 0.35f;

    public int zombieDamage = 15;

    private void Start()
    {
        bloodImage.enabled = false;
    }

    public void ZombieAttackEvent()
    {
        if (target.IsPlayerAlive())
        {
            if (target == null)
            {
                return;
            }

            target.TakeDamagePlayer (zombieDamage);
            StartCoroutine(Blood());
        }
        else
        {
            GetComponent<Animator>().SetBool("Attack", false);
        }
    }

    private IEnumerator Blood()
    {
        bloodImage.enabled = true;
        yield return new WaitForSeconds(bloodImpactTime);
        bloodImage.enabled = false;
    }
}
