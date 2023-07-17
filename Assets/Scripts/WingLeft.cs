using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingLeft : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _listFirePoint;
    
    private float fire_rate_weapon = 4.0f;
    
    private IEnumerator spawnWingBullet1()
    {
        Transform fire = ObjectPutter.Instance.PutObject(SpawnerType.WingBullet1);
        fire.position = _listFirePoint[0].position;
        fire.rotation = Quaternion.Euler(0f, 0f, 5.0f);


        fire.GetComponent<Wing1>().ActivateWing1();

        yield return null;
    }

    private IEnumerator StartFire1()
    {
        //Gia tri cho luc dau
        yield return new WaitForSeconds(0);

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
