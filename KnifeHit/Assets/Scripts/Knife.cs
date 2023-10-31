using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Knife : MonoBehaviour
{
    [SerializeField]
    private float force;

    private bool movable = true;

    [SerializeField]
    private Gamemanager gamemanager;

    private void Update()
    {
        if (movable)
        {
            transform.position += Vector3.up * force * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wood"))
        {
            movable = false;
            this.transform.SetParent(other.transform);
        }
        else if (other.gameObject.CompareTag("Fruit"))
        {
            //todo
            other.gameObject.SetActive(false);
            gamemanager.DecreaseFruit();
            // set up parent the knifes to the wood.
        }
    }
}
