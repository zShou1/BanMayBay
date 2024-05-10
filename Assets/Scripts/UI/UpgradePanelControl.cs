using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradePanelControl : MonoBehaviour
{
    public void NextLevel()
    {
        GameManager.Instance.CurrentLevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(false);
    }
}
