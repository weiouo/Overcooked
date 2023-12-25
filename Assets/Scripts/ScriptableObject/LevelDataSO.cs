using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class LevelDataSO : ScriptableObject
{
    public string levelName;
    public float levelTime;
    public List<int> levelScores;
    public int highestScore = 0;
}
