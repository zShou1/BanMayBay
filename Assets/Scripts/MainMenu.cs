using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject exitUI;
    
    [SerializeField]
    private GameObject hdUI;

    [SerializeField] private GameObject HighScorePanel;

    [SerializeField] private GameObject settingPanel;
    private void Awake()
    {
        exitUI.SetActive(false);
        hdUI.SetActive(false);
        HighScorePanel.SetActive(false);
        settingPanel.SetActive(false);
    }

    public void ExitButton()
    {
        exitUI.SetActive(true);
    }
    public void StartGame()
    {       
/*        PlayerPrefs.SetInt("Coin", 0);*/
        SceneManager.LoadScene(1);
    }
    public void Social()
    {
        Application.OpenURL("https://www.facebook.com/ddbinh01");
    }

    public void YesBTN()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void hdButton()
    {
        hdUI.SetActive(true);
    }

    public void hdNoBTN()
    {
        hdUI.SetActive(false);
    }

    public void NoBTN()
    {
        exitUI.SetActive(false);
    }

    public void HighScoreBTN()
    {
        HighScorePanel.SetActive(true);
    }

    public void SettingBTN()
    {
        settingPanel.SetActive(true);
    }
}
