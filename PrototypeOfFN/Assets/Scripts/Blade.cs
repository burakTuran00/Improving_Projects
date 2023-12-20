using UnityEngine;

public class Blade : MonoBehaviour
{
    private Camera mainCamera;

    private Collider bladeCollider;

    private bool slicing;

    public Vector3 direction { get; private set; }

    [SerializeField]
    private float slicedForce = 5.0f;

    [SerializeField]
    private float minSliceVelocity = 0.01f;

    private TrailRenderer bladeTrail;

    private AudioSource bladeCutSound;

    private void Awake()
    {
        bladeCollider = GetComponent<Collider>();
        mainCamera = Camera.main;
        bladeTrail = GetComponentInChildren<TrailRenderer>();
        bladeCutSound = GetComponent<AudioSource>();
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
        Vector3 newPosition =
            mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0.0f;

        transform.position = newPosition;

        slicing = true;

        bladeCollider.enabled = true;
        bladeTrail.enabled = true;
        bladeTrail.Clear();
    }

    public void StopSlicing()
    {
        slicing = false;
        bladeCollider.enabled = false;
        bladeTrail.enabled = false;
    }

    private void ContinueSlicing()
    {
        Vector3 newPosition =
            mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0.0f;

        direction = newPosition - transform.position;

        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;

        transform.position = newPosition;
    }

    public void PlayCuttingSound()
    {
        bladeCutSound.Play();
    }

    public float GetSlicedForce()
    {
        return slicedForce;
    }
}
