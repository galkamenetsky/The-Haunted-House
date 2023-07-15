using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    private Transform mainCamera;
    private CharacterController controller;

    [Header("Parameters")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float rotationSpeed;
    private float gravityValue = -9.81f;
    private Vector2 moveVector;

    //Runtime
    private Vector3 playerVelocity;
    private float currentSpeed;
    private bool groundedPlayer;
    private bool isJump;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main.transform;
    }


    private void Update()
    {
        HandleMovement();
        HandleAnimations();
    }

   

    private void HandleMovement()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y <= 0)
        {
            playerVelocity.y = -0.1f;
        }

        Vector3 move = new Vector3(moveVector.x, 0, moveVector.y).normalized;
      
      
        if (move != Vector3.zero)
        {
            Vector3 adjustedDirection = Quaternion.AngleAxis(mainCamera.eulerAngles.y, Vector3.up) * move;
            MakeRotate(adjustedDirection);
            MakeMove(adjustedDirection);
            currentSpeed = move.magnitude;
        }
        else
        {
            currentSpeed = 0f;
        }

        // Changes the height position of the player..
        if (isJump && groundedPlayer)
        {
            MakeJump();
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

 

    private void MakeMove(Vector3 direction)
    {
        Vector3 movement = direction * (playerSpeed * Time.deltaTime);
        controller.Move(movement);

     
    }

    private void MakeRotate(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.LookAt(transform.position + direction);
    }

    private void MakeJump()
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        isJump = false;
    }

    private void HandleAnimations()
    {
        animator.SetFloat("Walk", currentSpeed);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (groundedPlayer && context.performed)
        {
            isJump = true;
            animator.SetTrigger("Jump");
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }
}
