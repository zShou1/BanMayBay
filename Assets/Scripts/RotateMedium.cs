using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateMedium : MonoBehaviour
{
    private void Awake()
    {
        transform.DORotate(new Vector3(0, 0, -20f), 1f);
    }
    IEnumerator rotatePhase1()
    {
        /*       yield return new WaitForSeconds(1f);*/
        while (true)
        {
            transform.DORotate(new Vector3(0, 0, 20f), 2f);
            yield return new WaitForSeconds(2f);
            transform.DORotate(new Vector3(0, 0, -20f), 2f);
            yield return new WaitForSeconds(2f);
        }
        yield return null;
    }
    IEnumerator rotate()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(rotatePhase1());
    }
    private void OnEnable()
    {
        StartCoroutine(rotate());
    }

}
