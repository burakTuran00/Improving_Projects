using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    public Vector3 direction;

    public float speed;

    public System.Action destroyed;

    private void Update()
    {
        this.transform.position += this.direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (destroyed != null)
        {
            this.destroyed.Invoke();
        }
        

        Destroy(this.gameObject);
    }
}
