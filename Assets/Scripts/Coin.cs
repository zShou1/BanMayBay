using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Class dung de xu ly khi Player an Coin
    [SerializeField]
    private int coinValue;

    void Awake()
    {
        //set currentCoin=0
        /*PlayerPrefs.HasKey("Coin");
        if (!PlayerPrefs.HasKey("Coin"))
        {
            PlayerPrefs.SetInt("Coin", 0);
        }*/
    }

    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(7f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            /*PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + coinValue);*/
            GameManager.Instance.CurrentCoin += coinValue;
            GameManager.Instance.TotalCoin += coinValue;
            gameObject.SetActive(false);
        }
    }
}
