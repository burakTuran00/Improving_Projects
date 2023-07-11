using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ZombieAttack : MonoBehaviour
{
    public AudioSource oughtSoundEffect;

    public PlayerHealth target;

    public Image bloodImage;

    public float bloodImpactTime = 0.35f;

    public int zombieDamage = 15;

    private void Start()
    {
        bloodImage.enabled = false;

        target = GameObject.FindObjectOfType<PlayerHealth>();
    }

    public void ZombieAttackEvent()
    {
        if (target.IsPlayerAlive())
        {
            if (target == null)
            {
                return;
            }
            
            oughtSoundEffect.Play();
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
