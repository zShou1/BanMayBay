using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private LevelLoader _levelLoader;

    private void OnEnable()
    {
        scoreText.text = "Your Score: " + GameManager.Instance.TotalScore + "\nOld High Score: " +
                         DataManager.Instance.OldHighScore;
    }

    public void OnSave()
    {
        Debug.Log(inputField.text);
        DataManager.Instance.SaveData(inputField.text, GameManager.Instance.TotalScore);
        PlayerPrefs.DeleteAll();
        _levelLoader.LoadLevel(0);
    }
}
