using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIControl : MonoBehaviour
{
    //Dung de Quan ly cac thanh phan cua Canvas
    [SerializeField]
    private TextMeshProUGUI coinText;
    [SerializeField]
    private TextMeshProUGUI currentWaveText;
    [SerializeField]
    private TextMeshProUGUI totalWaveText;
    [SerializeField]
    private GameObject pauseMenuGameUI;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject loseUI;


    private void Awake()
    {
        Time.timeScale = 1f;
        loseUI.SetActive(false);
        PlayerPrefs.SetInt("Coin", 0);
        PlayerPrefs.HasKey("currentWave");
        if (!PlayerPrefs.HasKey("currentWave"))
        {
            PlayerPrefs.SetInt("currentWave", 1);
        }
        PlayerPrefs.HasKey("totalWave");
    }

    void Update()
    {
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        currentWaveText.text = PlayerPrefs.GetInt("currentWave").ToString();
        totalWaveText.text = PlayerPrefs.GetInt("totalWave").ToString();
        StartCoroutine(checkLose());
    }
    IEnumerator checkLose()
    {
        //Khi player no thi Lose, dung game va hien UI Lose
        yield return null;
        if (_player.active == false)
        {
            yield return new WaitForSeconds(2f);
            Time.timeScale = 0f;
            loseUI.SetActive(true);
        }
    }
    public void Resume()
    {
        pauseMenuGameUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        pauseMenuGameUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reload()
    {
        Time.timeScale = 1f;
/*        PlayerPrefs.SetInt("Coin", 0);*/
        SceneManager.LoadScene(1);  
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);  
    }
}
