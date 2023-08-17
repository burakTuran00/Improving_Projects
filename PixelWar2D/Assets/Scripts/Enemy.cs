using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;

    public bool flip;

    public float speed = 1.0f;

    private void Update()
    {
        Vector3 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1f * (flip ? -1f : 1f);
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1f : 1f);
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }
}
