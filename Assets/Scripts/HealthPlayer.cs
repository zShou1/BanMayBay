using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : HealthManager
{
    [SerializeField]
    private Transform healthBar;

    [SerializeField]
    private Transform currentHealthBar;

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
            currentHealthBar.localScale = new Vector3((float)currentHealth / health, 1f, 1f);
        }
        

        if (currentHealth <= 0)
        {
            currentHealthBar.localScale = new Vector3(0, 1f, 1f);
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
}
