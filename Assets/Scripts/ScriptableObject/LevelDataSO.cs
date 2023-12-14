using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class LevelDataSO : ScriptableObject
{
    public int levelTime;
    public List<int> levelScores;
}
