using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _listFirePoint;

    [SerializeField]
    private List<ParticleSystem> _listFirePointEffect;

    private float fire_rate_weapon = 0.15f;
    //BT

    private IEnumerator SpawnBullet()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet1.position = _listFirePoint[0].position;
        bullet1.rotation = Quaternion.Euler(0f, 0f, 0f);
        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet2.position = _listFirePoint[1].position;
        bullet2.rotation = Quaternion.Euler(0f, 0f, 0f);
        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet3.position = _listFirePoint[2].position;
        bullet3.rotation = Quaternion.Euler(0f, 0f, 1f);
        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet4.position = _listFirePoint[3].position;
        bullet4.rotation = Quaternion.Euler(0f, 0f, -1f);
        bullet1.GetComponent<Bullet>().Activate();
        bullet2.GetComponent<Bullet>().Activate();
        bullet3.GetComponent<Bullet>().Activate();
        bullet4.GetComponent<Bullet>().Activate();

        Transform fire1 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        fire1.position = _listFirePoint[0].position;
        Transform fire2 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        fire2.position = _listFirePoint[1].position;

        Transform fire3 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        fire3.position = _listFirePoint[2].position;

        Transform fire4 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        fire4.position = _listFirePoint[3].position;

        _listFirePointEffect[0].Play();
        _listFirePointEffect[1].Play();
        _listFirePointEffect[2].Play();
        _listFirePointEffect[3].Play();
        yield return null;
    }

    private IEnumerator StartFire()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            StartCoroutine(SpawnBullet());
            yield return new WaitForSeconds(fire_rate_weapon);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(StartFire());

    }

}
