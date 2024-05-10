using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingRight : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _listFirePoint;

    public Vector3 _lastPos;
    private float fire_rate_weapon = 4.0f;

    private IEnumerator spawnWingBullet1()
    {
        Transform fire1 = ObjectPutter.Instance.PutObject(SpawnerType.WingBullet1);
        fire1.position = _listFirePoint[0].position;
        fire1.rotation = Quaternion.Euler(0f, 0f, -5.0f);


        fire1.GetComponent<Wing1>().ActivateWing1();

        yield return null;
    }

    private IEnumerator StartFire1()
    {
        //Gia tri cho luc dau
        yield return new WaitForSeconds(1.0f);

        while (true)
        {
            StartCoroutine(spawnWingBullet1());

            yield return new WaitForSeconds(fire_rate_weapon);
        }
        yield return null;
    }

    private void OnEnable()
    {
        StartCoroutine(StartFire1());

    }
    
}
