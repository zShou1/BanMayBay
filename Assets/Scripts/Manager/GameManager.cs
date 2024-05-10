using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public List<SupportShip> SupportShips;
    
    public int CurrentScore
    {
        set
        {
            PlayerPrefs.SetInt("currentScore", value);
        }
        get
        {
            return PlayerPrefs.GetInt("currentScore", 0);
        }
    }

    public int CurrentCoin
    {
        set
        {
            PlayerPrefs.SetInt("currentCoin", value);
        }
        get
        {
            return PlayerPrefs.GetInt("currentCoin", 0);
        }
    }
    
    public int CurrentLevel
    {
        set
        {
            PlayerPrefs.SetInt("currentLevel", value);
        }
        get
        {
            return PlayerPrefs.GetInt("currentLevel", 1);
        }
    }

    public int TotalScore
    {
        set
        {
            PlayerPrefs.SetInt("totalScore", value);
        }
        get
        {
            return PlayerPrefs.GetInt("totalScore");
        }
    }

    public int TotalCoin
    {
        set
        {
            PlayerPrefs.SetInt("totalCoin", value);
        }
        get
        {
            return PlayerPrefs.GetInt("totalCoin");
        }
    }

    public void ResetTotalPrefs()
    {
        if (CurrentLevel == 1)
        {
            TotalCoin = 0;
            TotalScore = 0;
            
        }
    }

    public void ResetCurrentPrefs()
    {
        CurrentCoin = 0;
        CurrentScore = 0;
    }

    private void Start()
    {
        ResetCurrentPrefs();
        ResetTotalPrefs();
        if (SceneManager.GetActiveScene().buildIndex==1)
        {
            if (CurrentLevel == 2)
            {
                SupportShips[0].Unlock();
            }

            if (CurrentLevel == 3)
            {
                SupportShips[1].Unlock();
            }
        }
    }
    
}
