using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class LevelDataSO : ScriptableObject
{
    public float levelTime;
    public List<int> levelScores;
}
