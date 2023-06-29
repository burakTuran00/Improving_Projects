using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float waySpeed;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        waySpeed = 0.375f;
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset +=
            new Vector2(0f, waySpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        IncreaseSpeed();
    }

    private void IncreaseSpeed()
    {
        waySpeed += 0.00001f;
    }
}
