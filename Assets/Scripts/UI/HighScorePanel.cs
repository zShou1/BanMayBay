using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScorePanel : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI nameText;
    
    [SerializeField] 
    private TextMeshProUGUI scoreText;
    private void OnEnable()
    {
        OnViewHighScoreSaved();
    }

    private void OnViewHighScoreSaved()
    {
        foreach (HighScoreData highScoreData in DataManager.Instance.highScoreDataList)
        {
            nameText.text = highScoreData.HighScorePlayerName.ToString();
            scoreText.text = highScoreData.HighScore.ToString();
        }
    }
    public void BackBTN()
    {
        gameObject.SetActive(false);
    }
}
