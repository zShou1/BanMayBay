using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaveBullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float speed = 3f;
    private Collider2D _collider2D;
    private int damage = 20;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        transform.DOScale(new Vector3(2, 0.6f, 0), 4.15f).SetLoops(-1);
        gameObject.SetActive(false);

/*        transform.rotation= Quaternion.Euler(0f, 0f, -90f);*/
    }

    public void Activate()
    {
        _rigidbody2D.velocity = -transform.up * speed;
        
        StartCoroutine(deActive());
    }
    private IEnumerator deActive()
    {
        
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<HealthPlayer>().DecreaHealth(damage);
            /*gameObject.SetActive(false);*/
        }
    }

}
