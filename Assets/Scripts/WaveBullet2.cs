using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveBullet2 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    float speed = 4.0f;
    private int damage = 40;

    public Transform playerTransform;
    public Vector2 direction;
    public float angle;
    float rotateSpeed = 200f;
    bool isPhase = true;
    private bool isFollow;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        isFollow = false;
        playerTransform = GameObject.FindWithTag("Player").transform;
        if (playerTransform == null)
        {
            gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        isPhase = true;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        StartCoroutine(Move2());
        StartCoroutine(activePhase());
    }

    public void FixedUpdate()
    {
        direction = (Vector2)playerTransform.position - _rigidbody2D.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, -transform.up).z;
        if (!isFollow)
        {
            _rigidbody2D.angularVelocity = 0f;
        }
        else
        {
            _rigidbody2D.angularVelocity = -rotateAmount * rotateSpeed;
        }
        if (isPhase)
        {
            _rigidbody2D.velocity = transform.up * speed;
        }
        else
        {
            _rigidbody2D.velocity = -transform.up * speed;
        }
        
    }

    IEnumerator Move2()
    {                      
        yield return new WaitForSeconds(0.5f);
        isFollow = true;
        yield return new WaitForSeconds(2.5f);
        isFollow = false;
        yield return new WaitForSeconds(5.0f);
        gameObject.SetActive(false);
    }
    IEnumerator activePhase()
    {
        //Su dung de chuyen trang thai dan bay xuong
        yield return new WaitForSeconds(0.5f);
        isPhase = false;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<HealthPlayer>().DecreaHealth(damage);
            Transform explosion =
            ObjectPutter.Instance.PutObject(SpawnerType.SmallExplosion);
            explosion.position = transform.position;
            gameObject.SetActive(false);
        }
    }
}
