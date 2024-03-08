using System.Threading;
using UnityEditor.MPE;
using UnityEngine;

public class Letter : MonoBehaviour, IPooledObject
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private ParticleSystem effect;
    [SerializeField] private char letterChar;
    [SerializeField] private int letterIndex;
    private const int LETTER_COUNT = 26;

    private const int yAxis = 17;
    private const int xAxis = 4;
    private const int zAxis = 0;
    private const float angle = 15f;
    private const float minForce = 18f;
    private const float maxForce = 22f;
    private const int lifeTime = 10;

    private void OnEnable() 
    {
        
    }

    private void OnDisable() 
    {
        
    }
    public void OnObjectSpawn()
    {
       
    }
    
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
