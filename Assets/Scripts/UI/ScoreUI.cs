using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private LevelDataSO levelDataSO;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private List<GameObject> stars;
    [SerializeField] private List<TextMeshProUGUI> scores;
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Start()
    {
        nameText.text = levelDataSO.name;
        for (int i = 0; i < stars.Count; i++)
        {
            scores[i].text = levelDataSO.levelScores[i].ToString();
            if (levelDataSO.highestScore < levelDataSO.levelScores[i])
            {
                stars[i].SetActive(false);
            }
        }
        scoreText.text = levelDataSO.highestScore.ToString();
    }
}
