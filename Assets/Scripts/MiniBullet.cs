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

    public IEnumerator ActivateMini()
    {
        //Active dan Mini ben trai
        pointMove = transform.position + new Vector3(-xRan, -yRan, 0);
        transform.DOMove(pointMove, 0.5f);
        yield return new WaitForSeconds(0.5f);
        FireToPlayer();
/*        StartCoroutine(Move2());*/

    }
    public IEnumerator ActivateMini2()
    {
        //Active dan Mini ben phai
        pointMove =  transform.position + new Vector3(xRan, -yRan, 0);
        transform.DOMove(pointMove, 0.5f);
        yield return new WaitForSeconds(0.5f);
        FireToPlayer();
/*        StartCoroutine(Move2());*/
    }

    void FireToPlayer()
    {
        direction = (Vector2)playerTransform.position - _rigidbody2D.position;
        direction.Normalize();
        _rigidbody2D.velocity = direction * speed;
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
