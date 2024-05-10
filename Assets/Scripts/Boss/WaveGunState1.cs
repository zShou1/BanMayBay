using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaveGunState1 : MonoBehaviour
{
    public Transform playerTransform;
    public float angleMin;
    public float angleMax;
    public Vector3 direction;
    public float angle;

    private bool isStop = true;
    [SerializeField]
    private List<Transform> _listFirePoint;


    
    private float fire_rate_weapon = 4.0f;
    //BT
    public float wait_time = 1.0f;
    private float angleClamp;

    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        direction = playerTransform.position - transform.position;    
        direction.Normalize();
        /*angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg+90;
        if (angle > angleMax)
        {
            angle = angleMax;
        }
        if(angle < angleMin)
        {
            angle = angleMin;
        }
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
*/
        angle = Vector2.Angle(-Vector2.up, (Vector2) direction);
        if (playerTransform.position.x < 0)
        {
            angle = -angle;
        }
        
        angleClamp = Mathf.Clamp(angle, angleMin, angleMax);

        
    }
    private IEnumerator spawnWave()
    {
        Transform fire1 = ObjectPutter.Instance.PutObject(SpawnerType.WaveBullet1);
        fire1.position = _listFirePoint[0].position;
        fire1.rotation = transform.rotation;
        fire1.GetComponent<WaveBullet>().Activate();

        yield return null;
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            if (!isStop)
            {
                transform.DORotate(new Vector3(0, 0, angleClamp), 1f);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(0f);
            }
        }
    }
    private IEnumerator StartFire1()
    {
        yield return new WaitForSeconds(wait_time);
        
        while (true)
        {
            isStop = true;
            StartCoroutine(spawnWave());

            yield return new WaitForSeconds(0.05f);

            StartCoroutine(spawnWave());
            yield return new WaitForSeconds(0.05f);

            StartCoroutine(spawnWave());
            yield return new WaitForSeconds(0.05f);

            StartCoroutine(spawnWave());
            isStop = false;
            yield return new WaitForSeconds(fire_rate_weapon);
            
        }
    }
    

    private void OnEnable()
    {
        StartCoroutine(StartFire1());
        StartCoroutine(Rotate());
    }

    private void OnDisable()
    {
        StopAllCoroutines();

    }
}