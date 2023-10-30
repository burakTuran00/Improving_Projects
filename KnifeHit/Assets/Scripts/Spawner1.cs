using UnityEngine;
using UnityEngine.UI;

public class Spawner1 : MonoBehaviour
{
    [SerializeField]
    private Button spawnButton;

    [SerializeField]
    private GameObject[] knifes;

    [SerializeField]
    private Image[] knifeImages;

    private int index;

    private void Start()
    {
        index = knifes.Length;
    }

    public void Throw()
    {
        if(index <= 0)
        {
            spawnButton.interactable = false;
            return;

            //todo restart game
        }

        index--;
        knifes[index].SetActive(true);
        knifeImages[index].enabled = false;
    }
}
