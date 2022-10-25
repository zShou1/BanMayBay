using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestRotate : MonoBehaviour
{
    public Transform playerTransform;
    void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }
    public Vector3 direction;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        
        direction = playerTransform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.DORotate(new Vector3(0, 0, angle + 90f), 1.0f);
         
      
    }

    // Update is called once per frame
    void Update()
    {

    }
}
