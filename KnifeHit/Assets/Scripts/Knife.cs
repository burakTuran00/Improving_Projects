using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Knife : MonoBehaviour
{
    [SerializeField]
    private float force;

    private bool movable = true;

    [SerializeField]
    private Gamemanager gamemanager;

    private Wood wood;

    private void Awake()
    {
        wood = FindAnyObjectByType<Wood>();
    }

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
            wood.CallHitVoice();
            movable = false;
            this.transform.SetParent(other.transform);
        }
        else if (other.gameObject.CompareTag("Fruit"))
        {
            //todo
            other.gameObject.GetComponent<Fruit>().CallParticleSystem();
            other.gameObject.SetActive(false);
            gamemanager.DecreaseFruit();
            // set up parent the knifes to the wood.
        }
    }
}
