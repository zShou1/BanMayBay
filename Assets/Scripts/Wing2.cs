using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wing2 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    float speed = 3.0f;
    private int damage = 20;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    public void ActivateWing2()
    {
        _rigidbody2D.velocity = -transform.up * speed;
        StartCoroutine(wait());
        
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }    
    public void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * 180));

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
