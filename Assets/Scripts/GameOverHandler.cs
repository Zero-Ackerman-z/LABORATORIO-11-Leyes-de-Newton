using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    private void LateUpdate()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.x < 0 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            Debug.Log("Game Over");
        }
    }
}
