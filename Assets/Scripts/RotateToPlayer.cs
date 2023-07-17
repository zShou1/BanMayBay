using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateToPlayer : MonoBehaviour
{
    private Transform playerTransform;
    private float angle;
    private Vector2 direction;
    private float angleClamp;
    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        direction = (Vector2) (playerTransform.position - transform.position);
        angle = Vector2.Angle(-transform.up, direction);
        if (playerTransform.position.x < 0)
        {
            angle = -angle;
        }
        angleClamp = Mathf.Clamp(angle, -20f, 20f);
        
    }

    IEnumerator rotate()
    {
        /*       yield return new WaitForSeconds(1f);*/
        while (true)
        {
            transform.DORotate(new Vector3(0, 0, angleClamp), 1f);
            yield return new WaitForSeconds(1f);
            /*transform.DORotate(new Vector3(0, 0, -angleClamp), 2f);
            yield return new WaitForSeconds(2f);*/
        }
        yield return null;
    }
    IEnumerator startRotate()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(rotate());
    }
    private void OnEnable()
    {
        StartCoroutine(startRotate());
    }

}