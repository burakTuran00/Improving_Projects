using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    private Rigidbody rb;

    private Transform initialPosition;

    public Joystick joystick;

    public float forwardSpeed = 1.0f;

    public float leftRightSpeed = 1.0f;

    public Vector2 minMaxX;

    [Header("Scale Settings")]
    public Vector3 decreaseScale;

    public Vector3 increaseScale;

    public float decreaseTime;

    public float increaseTime; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        InvokeRepeating(nameof(Scaling), decreaseTime, decreaseTime);
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            decreaseScaling();
        }
        else if (other.gameObject.CompareTag("FinishLine"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            other.gameObject.SetActive(false);
            increaseScaling();
        }
        
    }

    private void Move()
    {
        transform.position =
            new Vector3(Mathf.Clamp(transform.position.x, minMaxX.x, minMaxX.y), transform.position.y, transform.position.z);

        float xMovement = joystick.Horizontal * leftRightSpeed * Time.deltaTime;
        transform.position += new Vector3(xMovement,0f , forwardSpeed* Time.deltaTime);
    }

    private void Scaling()
    {
        this.transform.localScale =
            Vector3.Lerp(transform.localScale, transform.localScale - decreaseScale, decreaseTime);


        if (transform.localScale.y < 0.15)
        {
            SceneManager.LoadScene(0);
            CancelInvoke(nameof(Scaling));
        }
    }

    private void increaseScaling()
    {
        this.transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale + increaseScale, increaseTime);
    }

    private void decreaseScaling()
    {
        this.transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale - increaseScale, increaseTime);
    } 


}
