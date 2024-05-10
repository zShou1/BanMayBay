using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanelControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI coinText;

    [SerializeField] private GameObject upgradePanel;

    [SerializeField] private GameObject upgradeButton;

    [SerializeField] private GameObject savedataPanel;
    [SerializeField] private LevelLoader _levelLoader;
    
    /*[SerializeField] private RectTransform menuRectTranform;*/

    /*private float xPosMenuRectTranform= 140f;*/

    private void OnEnable()
    {
        Debug.Log(DataManager.Instance.OldHighScore);
        upgradeButton.SetActive(true);
        scoreText.text = GameManager.Instance.TotalScore.ToString();
        coinText.text = "+"+GameManager.Instance.CurrentCoin.ToString();
        /*if (GameManager.Instance.CurrentLevel == 3)
        {
            upgradeButton.SetActive(false);
            menuRectTranform.anchoredPosition = new Vector2(0, menuRectTranform.anchoredPosition.y);
        }
        else
        {
            menuRectTranform.anchoredPosition= new Vector2(xPosMenuRectTranform, menuRectTranform.anchoredPosition.y);
        }*/
    }

    public void OnUpgradePanel()
    {
        upgradePanel.SetActive(true);
        gameObject.SetActive(false);
    }
    
    public void NextLevel()
    {
        if (GameManager.Instance.CurrentLevel == 5)
        {
            GameManager.Instance.CurrentLevel = 1;
            if (GameManager.Instance.TotalScore > DataManager.Instance.OldHighScore)
            {
                OnSaveDataPanel();
            }
            else
            {
                PlayerPrefs.DeleteAll();
                _levelLoader.LoadLevel(0);
            }
        }
        else
        {
            GameManager.Instance.CurrentLevel++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameObject.SetActive(false);
        }
        
    }

    public void OnSaveDataPanel()
    {
        savedataPanel.SetActive(true);
    }
    public void OnMenuScene()
    {
        if (GameManager.Instance.CurrentLevel == 5 && GameManager.Instance.TotalScore>DataManager.Instance.OldHighScore)
        {
            OnSaveDataPanel();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
