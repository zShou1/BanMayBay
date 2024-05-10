using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private Image slider;
    [SerializeField] private TextMeshProUGUI percentText;

    public void LoadLevel(int sceneIndex)
    {
        DOTween.KillAll();
        loadingPanel.SetActive(true);
        StartCoroutine(LoadAsychronously(sceneIndex));
    }

    IEnumerator LoadAsychronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.fillAmount = progress;
            percentText.text = progress * 100f + "%";
            Debug.Log(progress);
            yield return null;
        }
    }
}