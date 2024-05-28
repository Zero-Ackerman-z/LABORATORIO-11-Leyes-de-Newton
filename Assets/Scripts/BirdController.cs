using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    private PlayerController controls;
    private Rigidbody rb;

    public float upForce = 5f;        
    public float downForce = 5f;      
    public float horizontalSpeed = 5f;
    public float rotationSpeed = 5f;  

    private float horizontalInput;

    private void Awake()
    {
        controls = new PlayerController();
        controls.Game.Move.performed += ctx => Movimiento(ctx);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        controls.Game.Enable();
    }

    private void OnDisable()
    {
        controls.Game.Disable();
    }

    void Update()
    {
        if (rb.velocity.y < 0)
        {
            float angle = Mathf.Lerp(0, -90, -rb.velocity.y / 10f); 
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 30); 
        }

        rb.velocity = new Vector3(0, rb.velocity.y, horizontalInput * horizontalSpeed);
    }

    public void Movimiento(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();

        if (inputVector.y > 0)
        {
            rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
        }
        else if (inputVector.y < 0)
        {
            rb.AddForce(Vector3.down * downForce, ForceMode.Impulse);
        }

        horizontalInput = inputVector.x;
    }
}

