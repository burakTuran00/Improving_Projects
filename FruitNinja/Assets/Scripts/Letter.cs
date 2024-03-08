using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private ParticleSystem effect;
    [SerializeField] private char letterChar;
    [SerializeField] private int letterIndex;
    private const int LETTER_COUNT = 26;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            GameManager gm = FindAnyObjectByType<GameManager>();
            gm.AddSentence(letterChar);
            gameObject.SetActive(false);
        }    
    }

    public char getLetterChar()
    {
        return letterChar;
    }
}
