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
            PauseGame();

        }
    }
    void PauseGame()
    {
        Time.timeScale = 0; 
        Debug.Log("El pájaro ha salido del rango de la cámara. Juego pausado.");
    }
}
