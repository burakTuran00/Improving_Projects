using UnityEngine;

public class PlayerFinalStructure : MonoBehaviour
{
    public Joystick joystick;

    private Vector3 direction;

    public float forwardSpeed = 1.0f;

    public float leftRightSpeed = 1.0f;

    public bool isMovable;

    private GameManager gameManager;

    private void OnEnable() 
    {
        gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        if(isMovable)
        {
        transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z);

        float xMovement = -joystick.Horizontal * leftRightSpeed * Time.deltaTime;
        float zMovement = -joystick.Vertical * forwardSpeed * Time.deltaTime;

        transform.position += new Vector3(xMovement, 0f, zMovement);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Bot"))
        {
            other.gameObject.GetComponentInChildren<Animator>().SetTrigger("Destroy");
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;

            if(gameManager != null)
            {
            gameManager.score--;
            
            if(gameManager.score < 0)
            {
                // cannot pass level
            }

            gameManager.scoreText.text = gameManager.score.ToString();
        }
            
        }
    }
}
