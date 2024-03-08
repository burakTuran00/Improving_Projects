using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
public class ThirdPersonShooterController : MonoBehaviour
{
   [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
   [SerializeField] private float normalSensitivity;
   [SerializeField] private float aimSensitivity;
   [SerializeField] private LayerMask aimColliderMask;
   [SerializeField] private GameObject bulletProjectTilePrefab;
   [SerializeField] private Transform spawnBulletPosition;
   [SerializeField] private Ammo ammo;

   private ThirdPersonController thirdPersonController;
   private StarterAssetsInputs starterAssetsInputs;
   private Animator animator;
   private bool isShootable = true;

   private void Awake() 
   {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>(); 
        animator = GetComponent<Animator>();
   }

   private void Update() 
   {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        Transform hitTransform = null;

        if(Physics.Raycast(ray, out RaycastHit raycastHit, 100f, aimColliderMask))
        {
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }

        if(starterAssetsInputs.aim)
        {
            isShootable = true;

            aimVirtualCamera.gameObject.SetActive(true);

            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);

            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

        }
        else
        {
            isShootable = false;

            aimVirtualCamera.gameObject.SetActive(false);

            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);

            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }

       if(starterAssetsInputs.shoot && isShootable) 
       {
            if(hitTransform != null )
            {
                if(hitTransform.GetComponent<BulletTarget>() != null)
                {
                    // hit target
                    
                }
                else
                {
                    // hit something else;
                   
                }
            }
            starterAssetsInputs.shoot = false;
            ammo.Fire();
            isShootable = false;
       }

       if(starterAssetsInputs.reload && ammo.isReloaded)
       {
            ammo.ReloadAmmo();
       }
   }
}
