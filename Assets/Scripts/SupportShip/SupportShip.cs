using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportShip : MonoBehaviour
{
    [SerializeField] private string name;

    private void Start()
    {
        gameObject.SetActive(IsUnlocked());
    }

    public bool IsUnlocked()
    {
        if (GameManager.Instance.CurrentLevel == 1)
        {
            PlayerPrefs.SetInt(name+ "_isUnlocked", 0);
            return false;
        }

        return PlayerPrefs.GetInt(name + "_isUnlocked", 0) == 1;
    }

    public void Unlock()
    {
        PlayerPrefs.SetInt(name+ "_isUnlocked", 1);
    }
}
