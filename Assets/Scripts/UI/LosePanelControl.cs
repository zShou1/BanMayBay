using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LosePanelControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinText;

    private void OnEnable()
    {
        scoreText.text = GameManager.Instance.TotalScore.ToString();
        coinText.text = "+"+GameManager.Instance.CurrentCoin.ToString();
    }
}
