using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBossHealth : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _listGameObject;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
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
