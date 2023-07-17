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
    float rotateSpeed = 200f;
    private int damage = 50;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        gameObject.SetActive(false);
        playerTransform = GameObject.FindWithTag("Player").transform;
        enemy3Transform = GameObject.FindWithTag("mEnemy3").transform;
    } 
    public void Activate()
        {
            //State 1 dan bay len tren 2f trong 0.3s
            pointMove = enemy3Transform.position + new Vector3(0, 2.0f, 0);
            
/*        transform.DOMove(pointMove, 0.3f).SetEase(Ease.Linear).OnComplete(delegate { isFollow = true; });*/
        isFollow = false;
        StartCoroutine(Move2());

        }

    private bool isFollow;
    public void FixedUpdate()
    {
        //State 2 dan duoi Player duoc viet trong ham Update
        direction = (Vector2)playerTransform.position - _rigidbody2D.position; 
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, -transform.right).z;
        if (!isFollow)
        {
            _rigidbody2D.angularVelocity = 0f;
        }
        else
        {
            _rigidbody2D.angularVelocity = -rotateAmount * rotateSpeed;
        }
        _rigidbody2D.velocity = -transform.right * speed; 
        
    }
    
    IEnumerator Move2()
    {
        yield return new WaitForSeconds(0.05f);
        isFollow = true;
        //State 3
        //Sau 3s, dan khong duoi theo Player nua, sau 8s se DeActive de tranh ton tai nguyen
        yield return new WaitForSeconds(3.0f);
        isFollow = false;
        /*_rigidbody2D.angularVelocity = 0;*/
        yield return new WaitForSeconds(5.0f);
        gameObject.SetActive(false);
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
