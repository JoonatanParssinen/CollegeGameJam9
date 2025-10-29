using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class PlayerMovement : MonoBehaviour
{
    public InventorySystem inventoryScript;
    public KeyPickup keyScript;
    public bool OnKey = false;
    public bool OnSafe = false;
    public GameObject Key;
    public Rigidbody rb;
    public GameObject camHolder;
    public float speed, sensitivity;
    public float walkSpeed;
    public float sprintSpeed;
    private Vector2 move, look;
    private float lookRotation;
    public bool grounded;
    public string currentItem;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            speed = sprintSpeed;
        }


        if (context.canceled)
        {

            speed = walkSpeed;
        }
    }

    public void OnPickup(InputAction.CallbackContext context)
    {
        Debug.Log("action Started");
        if (context.started)
        {
            Debug.Log($"Onkey is {OnKey}");
            if (OnKey == true)
            {
                Debug.Log($"Onkey is {OnKey}2");
                inventoryScript.addItem(currentItem);
                keyScript.destroyItem();
            }
        }
    }
    public void OnOpenSafe(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (OnSafe == true)
            {
                Debug.Log("Safe Opened");
                // koodi safen aukasemisee tähä
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y);
        targetVelocity *= speed;

        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocityChange = (targetVelocity - currentVelocity);
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    void Look()
    {
        transform.Rotate(Vector3.up * look.x * sensitivity);

        lookRotation += (-look.y * sensitivity);
        lookRotation = Mathf.Clamp(lookRotation, -90, 90);
        camHolder.transform.eulerAngles = new Vector3(lookRotation, camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
{
    Cursor.lockState = CursorLockMode.Locked;
    inventoryScript = FindFirstObjectByType<InventorySystem>();
    keyScript = FindFirstObjectByType<KeyPickup>();
}

    // Update is called once per frame
    void LateUpdate()
    {
        Look();
    }

    public void SetGrounded(bool state)
    {
        grounded = state;
    }
}
