using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PipeConfiguration", menuName = "ScriptableObjects/PipeConfiguration", order = 1)]
public class PipeConfiguration : ScriptableObject
{
    public float minHeight = -2f;   
    public float maxHeight = 2f;    
    public float pipeSpacing = 4f;  
}