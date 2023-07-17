using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float speed = 12f;
    private Collider2D _collider2D;
    public int damage = 5;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        _rigidbody2D.velocity = transform.up * speed;
    }

    //Xu ly va cham, khi Bullet ban vao cac muc tieu se tru Health, tao hieu ung roi DeActive
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Enemy"))
        {
            enemy.GetComponent<BaseEnemy>().DecreaHealth(damage);
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
            vfx.position = transform.position;
            gameObject.SetActive(false);
        }
        if (enemy.CompareTag("mEnemy3"))
        {
            enemy.GetComponent<BaseEnemy>().DecreaHealth(damage);
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
            vfx.position = transform.position;
            gameObject.SetActive(false);
        }
        if (enemy.CompareTag("winggun"))
        {
            enemy.GetComponent<WingGun>().DecreaHealth(damage);
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
            vfx.position = transform.position;
            gameObject.SetActive(false);
        }
        if (enemy.CompareTag("minigun"))
        {
            enemy.GetComponent<MiniGun>().DecreaHealth(damage);
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
            vfx.position = transform.position;
            gameObject.SetActive(false);
        }
        if (enemy.CompareTag("wavegun"))
        {
            enemy.GetComponent<WaveGunHealth>().DecreaHealth(damage);
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
            vfx.position = transform.position;
            gameObject.SetActive(false);
        }
        if (enemy.CompareTag("Shield"))
        {

            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
            vfx.position = transform.position;
            gameObject.SetActive(false);
        }
        if (enemy.CompareTag("handgun"))
        {
            enemy.GetComponent<HandGunHealth>().DecreaHealth(damage);
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
            vfx.position = transform.position;
            gameObject.SetActive(false);

        }
        if (enemy.CompareTag("Boss"))
        {
            enemy.GetComponent<BossHealth>().DecreaHealth(damage);
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
            vfx.position = transform.position;
            gameObject.SetActive(false);

        }
    }
}

