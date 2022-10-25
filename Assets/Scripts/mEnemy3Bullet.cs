using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class mEnemy3Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float speed = 5.0f;
    private Collider2D _collider2D;
    public Transform playerTransform;
    public Transform enemy3Transform;
    public Vector2 direction;
    public Vector3 pointMove;
    public float angle;
    float rotateSpeed = 200f;
    private int damage = 50;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        gameObject.SetActive(false);
        playerTransform = GameObject.FindWithTag("Player").transform;
        enemy3Transform = GameObject.FindWithTag("mEnemy3").transform;
        //transform.rotation= Quaternion.Euler(0f, 0f, -90f);
    } 
    public void Activate()
        {
            pointMove = enemy3Transform.position + new Vector3(0, 2.0f, 0);



        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.DOMove(pointMove, 0.3f);
        //transform.DORotateQuaternion(Quaternion.AngleAxis(angle + 90f, Vector3.forward), 0.3f);



    }
    public void Update()
    {

        //transform.rotation= Quaternion.Euler(0f, 0f, -90f);
        //transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        //transform.up = playerTransform.position - transform.position;

            direction = (Vector2)playerTransform.position - _rigidbody2D.position;
            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, -transform.right).z;
            _rigidbody2D.angularVelocity = -rotateAmount * rotateSpeed;
            _rigidbody2D.velocity = -transform.right * speed;
               
            

        IEnumerator Move2()
        {
            yield return new WaitForSeconds(3.0f);
            _rigidbody2D.angularVelocity = 0;
            yield return new WaitForSeconds(2.0f);
            GameObject.FindGameObjectWithTag("Rocket").SetActive(false);
        }
        StartCoroutine(Move2());
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
