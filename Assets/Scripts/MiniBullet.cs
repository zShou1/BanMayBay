using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MiniBullet : MonoBehaviour
{
    //Dan Minigun
    private Rigidbody2D _rigidbody2D;
    float speed = 7.0f;
    private int damage = 20;
    float xRan ;
    float yRan ;
    public Transform playerTransform;
    public Vector2 direction;
    public Vector3 pointMove;
    float rotateSpeed = 200f;
    private bool isFollow;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        isFollow = false;
        gameObject.SetActive(false);

        playerTransform = GameObject.FindWithTag("Player").transform;
        //Dan bay ra voi khoang cach ngau nhien
        xRan = Random.Range(1.0f, 2.0f);
        yRan = Random.Range(1.0f, 2.0f);
    }

    public void ActivateMini()
    {
        //Active dan Mini ben trai
        pointMove = transform.position + new Vector3(-xRan, -yRan, 0);
        transform.DOMove(pointMove, 0.5f);
        StartCoroutine(Move2());

    }
    public void ActivateMini2()
    {
        //Active dan Mini ben phai
        pointMove =  transform.position + new Vector3(xRan, -yRan, 0);
        transform.DOMove(pointMove, 0.5f);
        StartCoroutine(Move2());
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
        _rigidbody2D.velocity = -transform.up * speed;
    }
    IEnumerator Move2()
    {
        yield return new WaitForSeconds(0.5f);
        isFollow = true;
        yield return new WaitForSeconds(1.0f);
        isFollow = false;
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<HealthPlayer>().DecreaHealth(damage);
            gameObject.SetActive(false);
        }
    }
}
