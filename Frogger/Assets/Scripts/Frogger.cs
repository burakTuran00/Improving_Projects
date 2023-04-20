using UnityEngine;
using System.Collections;
public class Frogger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite leapSprite;
    public Sprite deadSprite;
    private Vector3 spawnPosition;
    private float farthestRow;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnPosition = transform.position;    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            RotateFrog(0f);
            Move(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            RotateFrog(180f);
            Move(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateFrog(90f);
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateFrog(-90f);
            Move(Vector3.right);
        }
    }

    private void Move(Vector3 direction)
    {
        Vector3 destinaiton = transform.position+ direction;

        Collider2D barrier = Physics2D.OverlapBox(destinaiton, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        Collider2D platform = Physics2D.OverlapBox(destinaiton, Vector2.zero, 0f, LayerMask.GetMask("Platform"));
        Collider2D obstacle = Physics2D.OverlapBox(destinaiton, Vector2.zero, 0f, LayerMask.GetMask("Obstacle"));

        if(barrier != null)
        {
            return;
        }

        if (platform != null)
        {
            transform.SetParent(platform.transform);
        }
        else
        {
            transform.SetParent(null);
        }

        if (obstacle != null && platform == null)
        {
            transform.position = destinaiton;
            Death();
        }
        else
        {
            if (destinaiton.y > farthestRow)
            {
                farthestRow = destinaiton.y;
                FindObjectOfType<GameManager>().AdvancedRow();
            }

            StartCoroutine(Leap(destinaiton));
        }
    }

    private void RotateFrog(float zRot)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, zRot);
    }

    IEnumerator Leap(Vector3 destination)
    {
        Vector3 startPosition = transform.position;

        float elapsed = 0.0f;
        float duration = 0.125f;

        spriteRenderer.sprite = leapSprite;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(startPosition, destination, t);
            elapsed += Time.deltaTime;
            yield return null;
        }    

        transform.position = destination;
        spriteRenderer.sprite = idleSprite;
    }

    public void Death()
    {
        StopAllCoroutines();

        transform.rotation = Quaternion.identity;
        spriteRenderer.sprite = deadSprite;
        enabled = false;

        FindObjectOfType<GameManager>().Died();
    }
    public void Respawn()
    {
        StopAllCoroutines();

        transform.rotation = Quaternion.identity;
        transform.position = spawnPosition;
        farthestRow = spawnPosition.y;
        spriteRenderer.sprite = idleSprite;
        gameObject.SetActive(true);
        enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle") && enabled && transform.parent == null)
        {
            Death();
        }    
    }
}
