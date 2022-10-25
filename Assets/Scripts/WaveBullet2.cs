using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class WaveBullet2 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    float speed = 3.0f;
    private int damage = 40;

    public Transform playerTransform;
    public Vector2 direction;
    public float angle;
    float rotateSpeed = 200f;
    bool isPhase = true;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        

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
        StartCoroutine(wait());
        StartCoroutine(activePhase());

    }

    public IEnumerator wait()
    {
        
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
    public void Update()
    {

        direction = (Vector2)playerTransform.position - _rigidbody2D.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, -transform.up).z;
        _rigidbody2D.angularVelocity = -rotateAmount * rotateSpeed;
        if (isPhase)
        {
            _rigidbody2D.velocity = transform.up * speed;
        }
        else
        {
            _rigidbody2D.velocity = -transform.up * speed;
        }



        IEnumerator Move2()
        {                      
            yield return new WaitForSeconds(3.0f);
            _rigidbody2D.angularVelocity = 0;
        }
        StartCoroutine(Move2());
    }
    IEnumerator activePhase()
    {
        yield return new WaitForSeconds(0.5f);
        isPhase = false;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<HealthPlayer>().DecreaHealth(damage);
        }
    }
}
