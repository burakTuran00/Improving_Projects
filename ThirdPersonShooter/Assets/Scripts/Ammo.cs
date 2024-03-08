using UnityEngine;
using TMPro;
using StarterAssets;
public class Ammo : MonoBehaviour
{
    #region Variables
    [SerializeField] private AudioSource fireSoundEffect;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private AudioClip[] soundClips;
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;
    private const int USEABLE_AMOUNT_BULLET = 14;
    [Range(0,14)]
    private int currentBulletAmount = 14;
    [SerializeField]  private int totalBulletAmount = 4; // to take on the ground;
    public bool isReloaded {get; private set;}
    private int addableAmount;
    #endregion

    private void Start() 
    {
        ammoText.text = currentBulletAmount.ToString();
        fireSoundEffect.clip = soundClips[0]; 
        isReloaded = false;
    }

    public void Fire()
    {
        if(currentBulletAmount <= 0 && totalBulletAmount >= 0) 
        {
            isReloaded = true;
            return;
        }
        
        fireSoundEffect.clip = soundClips[0];
        currentBulletAmount--;
        ammoText.text = currentBulletAmount.ToString();
        fireSoundEffect.Play();
    }

    public void ReloadAmmo() // doesn't work
    {
        if(totalBulletAmount <= 0 && currentBulletAmount <= 0)
        {
            isReloaded = false;
            return;
        }
        
        addableAmount = USEABLE_AMOUNT_BULLET - currentBulletAmount;
        bool canReloadFullAmmo = (totalBulletAmount - addableAmount) < 0 ? false : true;

        if(canReloadFullAmmo)
        {
            currentBulletAmount = USEABLE_AMOUNT_BULLET ;
            totalBulletAmount -= addableAmount;
        }
        else
        {
            currentBulletAmount = ((totalBulletAmount + currentBulletAmount) > USEABLE_AMOUNT_BULLET) ? USEABLE_AMOUNT_BULLET : (totalBulletAmount + currentBulletAmount);
            totalBulletAmount = 0;
            isReloaded = false;
        }

        ammoText.text = currentBulletAmount.ToString();

       // todo: make reload sound
    }
}