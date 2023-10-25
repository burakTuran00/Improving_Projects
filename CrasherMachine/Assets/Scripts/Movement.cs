using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Movement : MonoBehaviour
{
    private Rigidbody rb;

    public Button pressButton;
    public float speed = 5.0f;

    public float force = 100f;

    public float timeSpeed = 0.005f;

    private Vector3 direction;

    public Vector2 minMaxX;

    public Transform downPosition;

    public Vector3 currentPosition;

    public bool horMovable = true;

    public bool verMovable = true;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Start()
    {
        currentPosition = transform.position;
    }

    private void Move()
    {
        if (horMovable && verMovable)
        {
            /*if (Input.GetKey(KeyCode.A))
            {
                direction = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction = Vector3.right;
            }
            else
            {
                direction = Vector3.zero;
            }*/

            
            transform.position =
                new Vector3(Mathf.Clamp(transform.position.x, minMaxX.x, minMaxX.y),
                    transform.position.y,
                    transform.position.z);

            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            return;
        }
    }

    public void RightButton()
    {
        if(horMovable && verMovable)
        {
            direction = Vector3.right;
            //doesn't work
        }
        else
        {
            direction = Vector3.zero;
        }
    }

    public void LeftButton()
    {
        if(horMovable && verMovable)
        {
            direction = Vector3.left;
            //doesn't work
        }
        else
        {
            direction = Vector3.zero;
        }
    }

    public void DownButton()
    {
        if (horMovable && verMovable)
        {
            horMovable = false;
            verMovable = false;
            MoveDown();
        }
        else
        {
            horMovable = true;
            verMovable = true;
            StartCoroutine(VerticalMovement());
        }

        direction = Vector3.zero;
    }

    private void MoveDown()
    {
            pressButton.interactable = false;
            currentPosition = transform.position;

            /*transform.position = Vector3.Lerp(currentPosition, downPosition.position,timeSpeed * Time.deltaTime);
             transform.position = downPosition.position;*/

            rb.AddForceAtPosition(Vector3.down * force, transform.position, ForceMode.Impulse);

            StartCoroutine(VerticalMovement());
    }

    IEnumerator VerticalMovement()
    {
        yield return new WaitForSeconds(1f);

        /*transform.position = Vector3.Lerp(downPosition.position, currentPosition, timeSpeed * Time.deltaTime);
        transform.position = currentPosition;*/
        //rb.AddForceAtPosition(currentPosition / 2, transform.position, ForceMode.Impulse);

        rb.AddForceAtPosition(Vector3.up * force, transform.position, ForceMode.Impulse);
        horMovable = true;
        verMovable = true;
        pressButton.interactable = true;

        StopAllCoroutines();
    }
}
