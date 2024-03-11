using System.Threading;
using UnityEditor.MPE;
using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private const int force = 15;
    private int useableForce;
    [SerializeField] private char letterChar;
    [SerializeField] private int letterIndex;
    private  Vector2 BorderToSpawnX = new Vector2(-3, 6);
    private Vector2 BorderToSpawnY  = new Vector2(12, 85);
    private const short maxLifeTime = 8;
    private const short xRotateAngle = -90;

    private float randomXPosition;
    private float randomYPosition;
    private void OnEnable() 
    {
       SetRandomValues();
    }
    private void OnDisable() 
    {
        
    }

    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.AddSentence(letterChar);
        }    
            Pooler.ReUse(this.gameObject);
            SetRandomValues();
    }

    public char getLetterChar()
    {
        return letterChar;
    }   

    private void SetRandomValues()
    {
        randomXPosition = Random.Range(BorderToSpawnX.x, BorderToSpawnX.y);
        randomYPosition = Random.Range(BorderToSpawnY.x, BorderToSpawnY.y);

        randomXPosition = Mathf.RoundToInt(randomXPosition);
        randomYPosition = Mathf.RoundToInt(randomYPosition);

        transform.position = new Vector3(randomXPosition, randomYPosition, 0f);
        transform.rotation = Quaternion.Euler(xRotateAngle, 0f, 0f);

        /*useableForce = Random.Range(force, force + 5);
        rb.AddForce(transform.forward * force, ForceMode.Impulse);*/
    }
}
