using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGunState2 : MonoBehaviour
{
    public float waitTime;

    [SerializeField]
    private List<Transform> _listFirePoint;

    private float fire_rate_weapon = 4.0f;
    
    private IEnumerator SpawnWaveBullet2()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.WaveBullet2);
        bullet1.position = _listFirePoint[0].position;
        bullet1.rotation = Quaternion.Euler(0f, 0f, 0f);


        bullet1.GetComponent<WaveBullet2>().Activate();

        yield return null;
    }
    
    private IEnumerator StartFire()
    {

        yield return new WaitForSeconds(waitTime);

        while (true)
        {
            StartCoroutine(SpawnWaveBullet2());
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SpawnWaveBullet2());
            
            yield return new WaitForSeconds(fire_rate_weapon);

        }
    }
    private void OnEnable()
    {
        StartCoroutine(StartFire());
    }
    private void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            gameObject.SetActive(false);
        }
    }

}
