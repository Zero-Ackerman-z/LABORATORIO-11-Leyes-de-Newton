using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionHandler : MonoBehaviour
{
    public float obstaclePushBackForce = 5f;    
    public float obstacleUpwardForce = 5f;      
    public float obstacleDownwardForce = 5f;    

    private Rigidbody birdRigidbody;

    void Start()
    {
        birdRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Vector3 pushDirection = transform.position - collision.transform.position;
            pushDirection.y = 0; 

            birdRigidbody.AddForce(pushDirection.normalized * obstaclePushBackForce, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("limit"))
        {
            Destroy(gameObject);
        }
    }
}
