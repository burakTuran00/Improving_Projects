using UnityEngine;

public class GearSystem : MonoBehaviour
{
    private AutoMovement autoMovement;

    [Range(0, 5)]
    public int gearNumber = 0;

    private void Awake()
    {
        autoMovement = GetComponent<AutoMovement>();
    }

    private void Update()
    {
        AdjustGear();
        AdjustSpeed();
    }

    public void AdjustGear()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !(gearNumber > 5))
        {
            gearNumber += 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && !(gearNumber < 0))
        {
            gearNumber -= 1;
        }
    }

    private void AdjustSpeed()
    {
        if (autoMovement != null)
        {
            if (gearNumber == 0)
            {
                autoMovement.moveSpeed = 0;
            }
            else if (gearNumber == 1)
            {
                autoMovement.moveSpeed = 50;
            }
            else if (gearNumber == 2)
            {
                autoMovement.moveSpeed = 100;
            }
            else if (gearNumber == 3)
            {
                autoMovement.moveSpeed = 150;
            }
            else if (gearNumber == 4)
            {
                autoMovement.moveSpeed = 225;
            }
            else if (gearNumber == 5)
            {
                autoMovement.moveSpeed = 275;
            }
        }
    }
}
