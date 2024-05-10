using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActiveHandGun : MonoBehaviour
{
    public GameObject handGun;
    
    void Update()
    {
        if (handGun.active == false)
        {
            gameObject.SetActive(false);
        }
    }
}
