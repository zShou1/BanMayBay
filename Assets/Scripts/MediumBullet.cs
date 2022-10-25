using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float speed = 12f;
    private Collider2D _collider2D;
    private int damage = 20;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        gameObject.SetActive(false);
        //transform.rotation= Quaternion.Euler(0f, 0f, -90f);
    }

    public void Activate()
    {
        _rigidbody2D.velocity = -transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<HealthPlayer>().DecreaHealth(damage);
        }
    }

}
