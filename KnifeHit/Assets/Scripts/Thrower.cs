using UnityEngine;
using UnityEngine.UI;

public class Thrower : MonoBehaviour
{
    [SerializeField]
    private Button spawnButton;

    [SerializeField]
    private GameObject[] knifes;

    [SerializeField]
    private Image[] knifeImages;

    private int index;

    [SerializeField]
    private Wood wood;

    [SerializeField]
    private Gamemanager gamemanager;

    private void Start()
    {
        index = knifes.Length;
    }

    public void Throw()
    {
        if (index <= 0)
        {
            spawnButton.interactable = false;
            return;

            //todo restart game
        }

        index--;
        knifes[index].SetActive(true);
        knifeImages[index].enabled = false;

        wood.IncreaseSpeed();
        gamemanager.IsLevelEnd();
    }

    public int GetIndex()
    {
        return index;
    }
}
