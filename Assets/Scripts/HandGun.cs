using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandGun : MonoBehaviour
{
    //Class nay su dung de Xoay HandGun va phun lua
    [SerializeField]
    private List<Transform> _listFirePoint;

    [SerializeField]
    private List<ParticleSystem> _listFirePointEffect;

    private float fire_rate_weapon = 14f;
    public float minAngle;
    public float maxAngle;
    public float waitTime;



    IEnumerator spawnFire()
    {
        
        _listFirePointEffect[0].transform.position = _listFirePoint[0].position;
        _listFirePointEffect[0].Play();
        transform.DORotate(new Vector3(0, 0, maxAngle), 5f);
        yield return new WaitForSeconds(5f);
       
        _listFirePointEffect[0].Stop();
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        yield return null;
    }

    private IEnumerator StartFire()
    {
        
        yield return new WaitForSeconds(waitTime);

        while (true)
        {
            transform.DORotate(new Vector3(0, 0, minAngle), 1.5f);
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(spawnFire());
            yield return new WaitForSeconds(fire_rate_weapon);
        }
        
    }

    private void OnEnable()
    {
        StartCoroutine(StartFire());
    }


}
