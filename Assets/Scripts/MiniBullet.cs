using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MiniBullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    float speed = 4.0f;
    private int damage = 20;
    float xRan ;
    float yRan ;
    Vector3 _pos;
    public Transform playerTransform;
    public Vector2 direction;
    public Vector3 pointMove;
    public float angle;
    float rotateSpeed = 200f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);

        playerTransform = GameObject.FindWithTag("Player").transform;
        xRan = Random.Range(1.0f, 2.0f);
        yRan = Random.Range(1.0f, 2.0f);
    }

    public void ActivateWing2()
    {
        pointMove = _pos = transform.position + new Vector3(-xRan, -yRan, 0);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.DOMove(pointMove, 0.5f);
        StartCoroutine(wait());

    }
    public void ActivateWing()
    {
        pointMove = _pos = transform.position + new Vector3(xRan, -yRan, 0);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.DOMove(pointMove, 0.5f);
        StartCoroutine(wait());

    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
    public void Update()
    {
        _pos = transform.position;
        direction = (Vector2)playerTransform.position - _rigidbody2D.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, -transform.up).z;
        _rigidbody2D.angularVelocity = -rotateAmount * rotateSpeed;
        _rigidbody2D.velocity = -transform.up * speed;



        IEnumerator Move2()
        {
            yield return new WaitForSeconds(1.0f);
            _rigidbody2D.angularVelocity = 0;
        }
        StartCoroutine(Move2());
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<HealthPlayer>().DecreaHealth(damage);
        }
    }
}
