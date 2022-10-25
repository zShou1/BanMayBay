using DG.Tweening;
using UnityEngine;
using System;
public class BaseEnemy : HealthManager
{
    private DOTweenPath mainPath;

    private DOTweenPath additionPath;

    private bool isRotateToPath;

    public ExplosionEffectType explosionType;
    public coinType coinType;
    private int damage=50;

    public void Init(DOTweenPath _mainPath, DOTweenPath _additionPath, bool _isRotateToPath)
    {
        mainPath = _mainPath;
        additionPath = _additionPath;
        transform.position = mainPath.wps[0];
        isRotateToPath = _isRotateToPath;
        StartMove();
    }

    public virtual void StartMove()
    {
        if (isRotateToPath)
        {
            transform.DOPath(mainPath.wps.ToArray(), mainPath.duration, mainPath.pathType, PathMode.TopDown2D, mainPath.pathResolution)
                .SetOptions(mainPath.isClosedPath)
                .SetDelay(mainPath.delay)
                .SetLoops(mainPath.loops, mainPath.loopType)
                .SetSpeedBased(mainPath.isSpeedBased)
                .SetLookAt(0f, Vector3.forward, Vector3.left)
                .SetEase(mainPath.easeCurve)
                .onComplete += delegate
                {
                    if (!additionPath)
                    {
                        DeActivate();
                    }
                    else
                    {
                        ContinueAdditionPath();
                    }
                };
        }
        else
        {
            transform.DOPath(mainPath.wps.ToArray(), mainPath.duration, mainPath.pathType, PathMode.TopDown2D, mainPath.pathResolution)
                .SetOptions(mainPath.isClosedPath)
                .SetDelay(mainPath.delay)
                .SetLoops(mainPath.loops, mainPath.loopType)
                .SetSpeedBased(mainPath.isSpeedBased)
                .SetEase(mainPath.easeCurve)
                .onComplete += delegate
                {
                    if (!additionPath)
                    {
                        DeActivate();
                    }
                    else
                    {
                        ContinueAdditionPath();
                    }
                };
        }

    }

    protected void ContinueAdditionPath()
    {
        transform.DOPath(additionPath.wps.ToArray(), additionPath.duration, additionPath.pathType, PathMode.TopDown2D,
                additionPath.pathResolution)
            .SetOptions(additionPath.isClosedPath)
            .SetDelay(additionPath.delay)
            .SetLoops(additionPath.loops, additionPath.loopType)
            .SetSpeedBased(additionPath.isSpeedBased)
            .SetEase(additionPath.easeCurve);
    }


    protected virtual void DeActivate()
    {
        gameObject.SetActive(false);
        OnDeActivate();
    }


    public override void DecreaHealth(int bulletDamage)
    {
        currentHealth -= bulletDamage;
        var explosionType = this.explosionType;

        if (currentHealth <= 0)
        {
            DeActivate();
            Transform explosion = null;
            switch (explosionType)
            {
                case ExplosionEffectType.SmallExplosion:
                    explosion = ObjectPutter.Instance.PutObject(SpawnerType.SmallExplosion);
                    break;
                case ExplosionEffectType.MediumExplosion:
                    explosion = ObjectPutter.Instance.PutObject(SpawnerType.MediumExplosion);
                    break;
            }
            explosion.position = transform.position;
            SpawnCoin();
            Reset();
        }
    }
    private Rigidbody2D cl;
    void SpawnCoin()
    {

        var coinType = this.coinType;
        Transform coin = null;
        switch (coinType)
        {
            case coinType.smallCoin:
                coin = ObjectPutter.Instance.PutObject(SpawnerType.smallCoin);
                break;
            case coinType.bigCoin:
                coin = ObjectPutter.Instance.PutObject(SpawnerType.bigCoin);
                coin = ObjectPutter.Instance.PutObject(SpawnerType.smallCoin);
                coin = ObjectPutter.Instance.PutObject(SpawnerType.smallCoin);
                break;
                if (cl.CompareTag("Coin"))
                {
                    cl.AddForce(new Vector3(0.25f, 0.01f, 0), ForceMode2D.Impulse);
                }
        }
        coin.position = transform.position;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthPlayer>().DecreaHealth(damage);
        }
    }
    /*private void OnTriggerEnter2D(Collider2D player)
    {
        
    }*/
    public void Reset()
{
    currentHealth = health;
    transform.DOKill();
}
    
    public event Action OnEnemyDestroy;


    protected virtual void OnDeActivate()
    {
        if (OnEnemyDestroy != null)
        {
            OnEnemyDestroy();
            OnEnemyDestroy = null;
        }
    }

}

