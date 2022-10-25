using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing1 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private int damage = 50;
    public float speed = 5.0f;
    public float currentSpeed;
    float deltaSpeed;
    public float minSpeed = 0.1f;
    Vector3 _lastPos;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
        gameObject.SetActive(false);
    }

    public void ActivateWing1()
    {
        currentSpeed = speed;

        _rigidbody2D.velocity = -transform.up * currentSpeed;
        
    }
    private IEnumerator spawnWingBullet2()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.WingBullet2);
        bullet1.position = _lastPos;
        bullet1.rotation = Quaternion.Euler(0f, 0f, 0f);

        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.WingBullet2);
        bullet2.position = _lastPos;
        bullet2.rotation = Quaternion.Euler(0f, 0f, -90f);
        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.WingBullet2);
        bullet3.position = _lastPos;
        bullet3.rotation = Quaternion.Euler(0f, 0f, -180f);
        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.WingBullet2);
        bullet4.position = _lastPos;
        bullet4.rotation = Quaternion.Euler(0f, 0f, -270f);


        bullet1.GetComponent<Wing2>().ActivateWing2();
        bullet2.GetComponent<Wing2>().ActivateWing2();
        bullet3.GetComponent<Wing2>().ActivateWing2();
        bullet4.GetComponent<Wing2>().ActivateWing2();




        yield return null;
    }
    private IEnumerator StartFire()
    {
        yield return StartCoroutine(spawnWingBullet2());



    }


    public void DeActivate()
    {
        
        StartCoroutine(StartFire());
        gameObject.SetActive(false);

        
    }    
    private void Update()
    {
        deltaSpeed = 1.0f;

        deltaSpeed *= Time.deltaTime;

        currentSpeed -= deltaSpeed;
        if (currentSpeed <= minSpeed)
        {
            _lastPos = gameObject.transform.position;
            DeActivate();  
        }
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<HealthPlayer>().DecreaHealth(damage);
        }
    }
}

