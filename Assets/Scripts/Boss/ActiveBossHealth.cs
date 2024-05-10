using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBossHealth : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _listGameObject;

    void Awake()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

//Tao 1 list quan ly cac sung Boss, khi sung bi tieu diet thi xoa di, khi list rong thi active collider
    void Update()
    {
        for(int i = _listGameObject.Count-1; i >=0; i--)
        {
            if (_listGameObject[i].active == false)
            {
                _listGameObject.RemoveAt(i);
            }
        }
        if (_listGameObject.Count == 0)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
}
