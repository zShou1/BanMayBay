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
        PlayerPrefs.HasKey("Coin");
        if (!PlayerPrefs.HasKey("Coin"))
        {
            PlayerPrefs.SetInt("Coin", 0);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + coinValue);
            gameObject.SetActive(false);
        }
    }
}
