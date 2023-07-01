using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float animateSpeed = 1.0f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update() 
    {
        AnimateBackGround();    
    }

    private void AnimateBackGround()
    {
        meshRenderer.material.mainTextureOffset += Vector2.up * animateSpeed * Time.deltaTime;
    }
}
