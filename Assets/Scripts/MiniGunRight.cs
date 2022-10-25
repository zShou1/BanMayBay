using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunRight : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _listFirePoint;


    private float fire_rate_weapon = 4.0f;
    //BT
    public float wait_time = 1.0f;

    private void Awake()
    {
        /*wait_time = this.wait_time;*/
    }


    private IEnumerator spawnMiniBullet()
    {
        Transform fire1 = ObjectPutter.Instance.PutObject(SpawnerType.MiniBullet);
        fire1.position = _listFirePoint[0].position;
        fire1.rotation = Quaternion.Euler(0f, 0f, -50.0f);
        /*        Transform fire2 = ObjectPutter.Instance.PutObject(SpawnerType.MiniBullet);
                fire2.position = _listFirePoint[1].position;
                fire2.rotation = Quaternion.Euler(0f, 0f, 50.0f);
                Transform fire3 = ObjectPutter.Instance.PutObject(SpawnerType.MiniBullet);
                fire3.position = _listFirePoint[2].position;
                fire3.rotation = Quaternion.Euler(0f, 0f, 50.0f);*/


        fire1.GetComponent<MiniBullet>().ActivateWing();
        /*        fire2.GetComponent<MiniBullet>().ActivateWing2();
                fire3.GetComponent<MiniBullet>().ActivateWing2();*/

        yield return null;
    }


    private IEnumerator StartFire1()
    {
        //Gia tri cho luc dau
        yield return new WaitForSeconds(wait_time);

        while (true)
        {
            StartCoroutine(spawnMiniBullet());

            yield return new WaitForSeconds(0.3f);

            StartCoroutine(spawnMiniBullet());

            yield return new WaitForSeconds(fire_rate_weapon);
        }

    }



    private void OnEnable()
    {
        StartCoroutine(StartFire1());

    }

}
