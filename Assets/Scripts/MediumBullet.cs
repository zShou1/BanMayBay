using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float speed = 10f;
    private Collider2D _collider2D;
    private int damage = 20;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        _rigidbody2D.velocity = -transform.up * speed;
        StartCoroutine(deActive());
    }

    IEnumerator deActive()
    {
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
