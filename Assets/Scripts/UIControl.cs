using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIControl : MonoBehaviour
{
    //Dung de Quan ly cac thanh phan cua Canvas
    [SerializeField]
    private TextMeshProUGUI coinText;
    [SerializeField] 
    private TextMeshProUGUI curentScoreText;
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
        PlayerPrefs.HasKey("currentWave");
        if (!PlayerPrefs.HasKey("currentWave"))
        {
            PlayerPrefs.SetInt("currentWave", 1);
        }
        PlayerPrefs.HasKey("totalWave");
    }

    void Update()
    {
        coinText.text = GameManager.Instance.TotalCoin.ToString();
        curentScoreText.text = "Score: "+GameManager.Instance.CurrentScore.ToString();
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
            /*GameManager.Instance.TotalScore += GameManager.Instance.CurrentScore;*/
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
/*        PlayerPrefs.SetInt("Coin", 0);*/
        DOTween.KillAll();
        SceneManager.LoadScene(1);
        GameManager.Instance.CurrentLevel = 1;
        GameManager.Instance.ResetTotalPrefs();
        GameManager.Instance.ResetCurrentPrefs();
        Time.timeScale = 1f;
    }
    public void MenuOnLose()
    {
        DOTween.KillAll();
        /*SceneManager.LoadScene(0);  */
        /*GameManager.Instance.CurrentLevel = 1;*/
        GameManager.Instance.TotalCoin -= GameManager.Instance.CurrentCoin;
        PlayerPrefs.DeleteAll();
        /*Time.timeScale = 1f;*/
    }
}
