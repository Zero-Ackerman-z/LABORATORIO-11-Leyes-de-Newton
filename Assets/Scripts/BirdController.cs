using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class BirdController : MonoBehaviour
{
    private PlayerController controls;
    private Rigidbody rb;

    public float upForce = 5f;        // Fuerza hacia arriba aplicada al presionar la barra espaciadora
    public float downForce = 5f;      // Fuerza hacia abajo aplicada al presionar la flecha hacia abajo
    public float rotationSpeed = 5f;  // Velocidad de rotación del pájaro al caer

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
        // Rotar el pájaro hacia abajo cuando cae
        if (rb.velocity.y < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), rotationSpeed * Time.deltaTime);
        }
    }

    public void Movimiento(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();

        if (inputVector.y > 0) // Si se presiona el botón de subir
        {
            rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
        }
        else if (inputVector.y < 0) // Si se presiona el botón de bajar
        {
            rb.AddForce(Vector3.down * downForce, ForceMode.Impulse);
        }
    }
}
