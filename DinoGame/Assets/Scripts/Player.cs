using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 direction;

    [Range(1, 10)] public float jumpForce = 8f;
    public float gravity = 9.8f * 2f;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        direction = Vector3.zero;
    }
    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;
        if (characterController.isGrounded)
        {
            direction = Vector3.down;
            if (Input.GetButton("Jump"))
            {
                direction = Vector3.up * jumpForce;
            }
        }
        characterController.Move(direction * Time.deltaTime);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
