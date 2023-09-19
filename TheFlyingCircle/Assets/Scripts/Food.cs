using System.Threading;
using UnityEngine;

public class Food : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollisionArea"))
        {
            gameObject.SetActive(false);
        }
    }

    public void PlayEatAudio()
    {
        audioSource.Play();
    }
}
