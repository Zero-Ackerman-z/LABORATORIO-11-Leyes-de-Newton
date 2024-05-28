using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PipeConfiguration", menuName = "ScriptableObjects/PipeConfiguration", order = 1)]
public class PipeConfiguration : ScriptableObject
{
    public float minHeight = -2f;   // Altura mínima de las tuberías
    public float maxHeight = 2f;    // Altura máxima de las tuberías
    public float pipeSpacing = 4f;  // Espacio entre tuberías
}