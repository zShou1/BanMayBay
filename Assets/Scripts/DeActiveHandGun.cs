using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActiveHandGun : MonoBehaviour
{
    public GameObject handGun;
    // Start is called before the first frame update
    void Awake()
    {
        /*gameObject.SetActive(true);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (handGun.active == false)
        {
            gameObject.SetActive(false);
        }
    }
}
