using UnityEngine;

public class Blade : MonoBehaviour
{
    private Camera mainCamera;

    private Collider bladeCollider;

    private bool slicing;

    public Vector3 direction { get; private set; }

    public float minSliceVelocity = 0.01f;

    private void Awake()
    {
        bladeCollider = GetComponent<Collider>();
        mainCamera = Camera.main;
    }

    private void OnEnable() 
    {
        StopSlicing();      
    }
    private void OnDisable() 
    {
        StopSlicing();    
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if (slicing)
        {
            ContinueSlicing();
        }
    }

    private void StartSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0.0f;

        transform.position = newPosition;

        slicing = true;
        bladeCollider.enabled = true;
    }

    private void StopSlicing()
    {
        slicing = false;
        bladeCollider.enabled = false;
    }

    private void ContinueSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0.0f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
    }
}
