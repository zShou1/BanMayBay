using DG.Tweening;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BaseEnemy : HealthManager
{
    private DOTweenPath mainPath;

    private DOTweenPath additionPath;

    private bool isRotateToPath;

    public ExplosionEffectType explosionType;
    public coinType coinType;
    public int damage=50;

    public void Init(DOTweenPath _mainPath, DOTweenPath _additionPath, bool _isRotateToPath)
    {
        mainPath = _mainPath;
        additionPath = _additionPath;
        transform.position = mainPath.wps[0];
        isRotateToPath = _isRotateToPath;
        StartMove();
    }
//Tao path di chuyen
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

//Func xu ly Health khi nhan Damage tu Player Bullet
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
                    GameManager.Instance.CurrentScore += 100;
                    GameManager.Instance.TotalScore += 100;
                    break;
                case ExplosionEffectType.MediumExplosion:
                    explosion = ObjectPutter.Instance.PutObject(SpawnerType.MediumExplosion);
                    GameManager.Instance.CurrentScore += 300;
                    GameManager.Instance.TotalScore += 300;
                    break;
            }
            explosion.position = transform.position;
            AudioManager.Instance.PlaySound(AudioManager.Instance.explosionSfx);
            SpawnCoin();
            Reset();
        }
    }
    private Rigidbody2D cl;
    
    void SpawnCoin()
    {
        var coinType = this.coinType;
        /*Transform coin = null;*/
        switch (coinType)
        {
            case coinType.smallCoin:
                Transform coin = ObjectPutter.Instance.PutObject(SpawnerType.smallCoin);
                coin.transform.position = transform.position;
                Rigidbody2D rbCoin = coin.GetComponent<Rigidbody2D>();
                rbCoin.AddForce(new Vector2(Random.Range(-1.5f,1.5f), Random.Range(2f,3f)), ForceMode2D.Impulse);
                break;
            case coinType.bigCoin:
                Transform coin1 = ObjectPutter.Instance.PutObject(SpawnerType.bigCoin);
                Transform coin2 = ObjectPutter.Instance.PutObject(SpawnerType.smallCoin);
                Transform coin3 = ObjectPutter.Instance.PutObject(SpawnerType.smallCoin);
                coin1.transform.position = transform.position;
                coin2.transform.position = transform.position;
                coin3.transform.position = transform.position;
                Rigidbody2D rbCoin1 = coin1.GetComponent<Rigidbody2D>();
                rbCoin1.AddForce(new Vector2(Random.Range(-1.5f,1.5f), Random.Range(2f,3f)), ForceMode2D.Impulse);
                Rigidbody2D rbCoin2 = coin2.GetComponent<Rigidbody2D>();
                rbCoin2.AddForce(new Vector2(Random.Range(-1.5f,1.5f), Random.Range(2f,3f)), ForceMode2D.Impulse);
                Rigidbody2D rbCoin3 = coin3.GetComponent<Rigidbody2D>();
                rbCoin3.AddForce(new Vector2(Random.Range(-1.5f,1.5f), Random.Range(2f,3f)), ForceMode2D.Impulse);
                break;
        }
        /*coin.position = transform.position;*/
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthPlayer>().DecreaHealth(damage);
            Transform explosion =
            ObjectPutter.Instance.PutObject(SpawnerType.SmallExplosion);
            explosion.position = transform.position;
            if (AudioManager.VibrateOn == 1)
            {
                Handheld.Vibrate();
            }
            DeActivate();
            Reset();
        }
    }

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

