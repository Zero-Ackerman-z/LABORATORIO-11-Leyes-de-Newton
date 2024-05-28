using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionHandler : MonoBehaviour
{
    public float obstaclePushBackForce = 5f;    // Fuerza de retroceso cuando se choca con un obst�culo
    public float obstacleUpwardForce = 5f;      // Fuerza hacia arriba al chocar con un obst�culo desde abajo
    public float obstacleDownwardForce = 5f;    // Fuerza hacia abajo al chocar con un obst�culo desde arriba

    private Rigidbody birdRigidbody;

    void Start()
    {
        birdRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detectar colisi�n con obst�culos
        if (collision.gameObject.CompareTag("Pipe"))
        {
            // Calcular direcci�n del empuje
            Vector3 pushDirection = transform.position - collision.transform.position;
            pushDirection.y = 0; // Solo empujar en el eje horizontal

            // Empujar al p�jaro hacia atr�s
            birdRigidbody.AddForce(pushDirection.normalized * obstaclePushBackForce, ForceMode.Impulse);

            // Empujar al p�jaro hacia arriba o hacia abajo seg�n la posici�n del obst�culo
            if (transform.position.y > collision.transform.position.y)
            {
                birdRigidbody.AddForce(Vector3.up * obstacleUpwardForce, ForceMode.Impulse);
            }
            else
            {
                birdRigidbody.AddForce(Vector3.down * obstacleDownwardForce, ForceMode.Impulse);
            }
        }
    }
}
