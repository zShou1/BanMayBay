using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumFire : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _listFirePoint;


    private float fire_rate_weapon = 1.0f;
    //BT

    //Turn dau ban 2 luot, moi luot 4 vien
    private IEnumerator SpawnBullet()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.MediumBullet);
        bullet1.position = _listFirePoint[0].position;
        bullet1.rotation = Quaternion.Euler(0f, 0f, 0f);
        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.MediumBullet);
        bullet2.position = _listFirePoint[1].position;
        bullet2.rotation = Quaternion.Euler(0f, 0f, 0f);
        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.MediumBullet);
        bullet3.position = _listFirePoint[2].position;
        bullet3.rotation = Quaternion.Euler(0f, 0f, 0f);
        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.MediumBullet);
        bullet4.position = _listFirePoint[3].position;
        bullet4.rotation = Quaternion.Euler(0f, 0f, 0f);

        bullet1.GetComponent<MediumBullet>().Activate();
        bullet2.GetComponent<MediumBullet>().Activate();
        bullet3.GetComponent<MediumBullet>().Activate();
        bullet4.GetComponent<MediumBullet>().Activate();
        yield return null;
    }
    
    //Turn 2 ban 2 luot, moi luot 5 vien
    private IEnumerator SpawnBullet2()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.MediumBullet);
        bullet1.position = _listFirePoint[0].position;
        bullet1.rotation = Quaternion.Euler(0f, 0f, -30f);
        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.MediumBullet);
        bullet2.position = _listFirePoint[1].position;
        bullet2.rotation = Quaternion.Euler(0f, 0f, -15f);
        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.MediumBullet);
        bullet3.position = _listFirePoint[2].position;
        bullet3.rotation = Quaternion.Euler(0f, 0f, 15f);
        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.MediumBullet);
        bullet4.position = _listFirePoint[3].position;
        bullet4.rotation = Quaternion.Euler(0f, 0f, 30f);
        Transform bullet5 = ObjectPutter.Instance.PutObject(SpawnerType.MediumBullet);
        bullet5.position = _listFirePoint[4].position;
        bullet5.rotation = Quaternion.Euler(0f, 0f, 0f);

        bullet1.GetComponent<MediumBullet>().Activate();
        bullet2.GetComponent<MediumBullet>().Activate();
        bullet3.GetComponent<MediumBullet>().Activate();
        bullet4.GetComponent<MediumBullet>().Activate();
        bullet5.GetComponent<MediumBullet>().Activate();
        yield return null;
    }


    private IEnumerator StartFire()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            StartCoroutine(SpawnBullet());
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(SpawnBullet());
            yield return new WaitForSeconds(fire_rate_weapon);
            StartCoroutine(SpawnBullet2());
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(SpawnBullet2());
            yield return new WaitForSeconds(fire_rate_weapon);
        }
    }
    private void OnEnable()
    {
        StartCoroutine(StartFire());

    }
    
}
