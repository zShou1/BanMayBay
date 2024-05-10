using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : HealthManager
{
    /*[SerializeField]
    private Transform healthBar;*/

    [SerializeField]
    private Image currentHealthBar;

    protected virtual void DeActivate()
    {
        gameObject.SetActive(false);
    }
    public override void DecreaHealth(int bulletDamage)
    {
        currentHealth -= bulletDamage;
        base.DecreaHealth(bulletDamage);
        if (currentHealth > 0)
        {
            /*currentHealthBar.localScale = new Vector3((float)currentHealth / health, 1f, 1f);*/
            currentHealthBar.fillAmount = (float)currentHealth / health;
        }
        

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            /*currentHealthBar.localScale = new Vector3(0, 1f, 1f);*/
            currentHealthBar.fillAmount = 0;
            DeActivate();
            Transform explosion =
            ObjectPutter.Instance.PutObject(SpawnerType.ExplosionPlayer);
            explosion.position = transform.position;            
            Reset();  
        }
    }

    public void Reset()
    {
        currentHealth = health;
        //transform.DOKill();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void Start()
    {
        InitHealthData();
        currentHealthBar.fillAmount = (float)currentHealth / health;
    }

    private void InitHealthData()
    {
        if (GameManager.Instance.CurrentLevel == 1)
        {
            currentHealth = health;
        }
        else
        {
            currentHealth = PlayerPrefs.GetInt("playerLastLevelHealth", health);
        }
    }

    public void SetLastLevelHealth()
    {
        PlayerPrefs.SetInt("playerLastLevelHealth", currentHealth);
    }
    
}
