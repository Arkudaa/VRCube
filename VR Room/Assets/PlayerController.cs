using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    private CharacterController characterController;
    private Vector2 movementInput;
    private Vector2 mouseInput;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Handle player movement
        MovePlayer();

        // Handle player rotation
        RotatePlayer();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {
        Vector3 movement = transform.forward * movementInput.y + transform.right * movementInput.x;
        movement.Normalize();

        characterController.Move(movement * movementSpeed * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        Vector3 rotation = transform.localEulerAngles;
        rotation.y += mouseInput.x * mouseSensitivity;

        transform.localEulerAngles = rotation;

        // Vertical rotation (looking up and down)
        rotation = Camera.main.transform.localEulerAngles;
        rotation.x -= mouseInput.y * mouseSensitivity;
        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);

        Camera.main.transform.localEulerAngles = rotation;
    }


}
