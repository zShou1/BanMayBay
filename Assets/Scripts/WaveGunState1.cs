using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaveGunState1 : MonoBehaviour
{
    public Transform playerTransform;
    public float angleMin;
    public float angleMax;
    [SerializeField]
    private List<Transform> _listFirePoint;


    private float fire_rate_weapon = 4.0f;
    //BT
    public float wait_time = 1.0f;
    private float lastAng;

    void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;

    }
    public Vector3 direction;
    public float angle;


    //bool checkTime = true;
    void Update()
    {
        direction = playerTransform.position - transform.position;    
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg+90;
        if (angle > angleMax)
        {
            angle = angleMax;
        }
        if(angle < angleMin)
        {
            angle = angleMin;
        }
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


    }
    private IEnumerator spawnWave()
    {

        Transform fire1 = ObjectPutter.Instance.PutObject(SpawnerType.WaveBullet1);
        fire1.position = _listFirePoint[0].position;
        fire1.rotation = Quaternion.Euler(0f, 0f, angle);



        fire1.GetComponent<WaveBullet>().Activate();


        yield return null;
    }


    private IEnumerator StartFire1()
    {
        //Gia tri cho luc dau
        
        yield return new WaitForSeconds(wait_time);

        while (true)
        {
            StartCoroutine(spawnWave());

            yield return new WaitForSeconds(0.05f);

            StartCoroutine(spawnWave());
            yield return new WaitForSeconds(0.05f);

            StartCoroutine(spawnWave());
            yield return new WaitForSeconds(0.05f);

            StartCoroutine(spawnWave());

            yield return new WaitForSeconds(fire_rate_weapon);
        }

    }



    private void OnEnable()
    {
        StartCoroutine(StartFire1());
    }

    private void OnDisable()
    {
        StopAllCoroutines();

    }
}