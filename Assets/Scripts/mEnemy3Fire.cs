using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mEnemy3Fire : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _listFirePoint;


    //private float fire_rate_weapon = 1.0f;
    //BT

    private IEnumerator SpawnBullet()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.MediumBullet);
        bullet1.position = _listFirePoint[0].position;
        bullet1.rotation = Quaternion.Euler(0f, 0f, 0f);
        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.MediumBullet);
        bullet2.position = _listFirePoint[1].position;
        bullet2.rotation = Quaternion.Euler(0f, 0f, 0f);

        bullet1.GetComponent<MediumBullet>().Activate();
        bullet2.GetComponent<MediumBullet>().Activate();

        yield return null;
    }
    private IEnumerator SpawnRocket()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Rocket);
        bullet1.position = _listFirePoint[2].position;
        bullet1.rotation = Quaternion.Euler(0f, 0f, 0f);


        bullet1.GetComponent<mEnemy3Bullet>().Activate();

        yield return null;
    }


    //private float time = 0;
    private IEnumerator StartFire()
    {
        //Gia tri cho luc dau
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            StartCoroutine(SpawnBullet());
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(SpawnBullet());
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(SpawnRocket());
            yield return new WaitForSeconds(2.8f);

        }
    }

    private void OnEnable()
    {
        StartCoroutine(StartFire());

    }

}
