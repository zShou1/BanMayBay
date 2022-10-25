using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateToPlayer : MonoBehaviour
{
    public float angleMin;
    public float angleMax;
    public Transform playerTransform;
    void Awake()
{
    playerTransform = GameObject.FindWithTag("Player").transform;
    }
public Vector3 direction;
public float angle;

    //bool checkTime = true;
    void Update()
{

    direction = playerTransform.position - transform.position;
    angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg+90f;
        if (angle > angleMax)
        {
            angle = angleMax;
        }
        if (angle < angleMin)
        {
            angle = angleMin;
        }
        transform.rotation = Quaternion.AngleAxis(angle , Vector3.forward);
        //        transform.DORotateQuaternion(Quaternion.AngleAxis(angle + 90f, Vector3.forward), 1.0f);

    }



}