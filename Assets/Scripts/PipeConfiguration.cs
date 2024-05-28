using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PipeConfiguration", menuName = "ScriptableObjects/PipeConfiguration", order = 1)]
public class PipeConfiguration : ScriptableObject
{
    public float minHeight = -2f;   // Altura m�nima de las tuber�as
    public float maxHeight = 2f;    // Altura m�xima de las tuber�as
    public float pipeSpacing = 4f;  // Espacio entre tuber�as
}