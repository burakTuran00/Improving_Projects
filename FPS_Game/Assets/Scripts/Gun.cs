using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;

    public float range = 100f;

    public Camera cross;

    // public ParticleSystem effect;
    public int maxAmmount = 30;

    private int currentAmount;

    public float reloadTime = 1f;

    private bool isReloading = false;

    public Animator animator;

    public Text ammount_Text;

    private void Awake()
    {
        currentAmount = maxAmmount;
        ammount_Text.text = "x" + currentAmount.ToString();
    }

    private void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (currentAmount <= 0f)
        {
            StartCoroutine(Releod());
            return;
        }
    }

    public void Shoot()
    {
        // effect.Play();
        currentAmount--;
        ammount_Text.text = "x" + currentAmount.ToString();
        RaycastHit hit;
        if (
            Physics
                .Raycast(cross.transform.position,
                cross.transform.forward,
                out hit,
                range)
        )
        {
            Debug.Log(hit.transform.name.ToString());
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage (damage);
            }
        }
    }

    IEnumerator Releod()
    {
        isReloading = true;
        Debug.Log("Reloding");
        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmount = maxAmmount;
        isReloading = false;
        ammount_Text.text = "x" + currentAmount.ToString();
    }
}
