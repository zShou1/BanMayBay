using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : MonoBehaviour
{
    [SerializeField] private List<Transform> _listFirePoint;

    /*[SerializeField] private List<ParticleSystem> _listFirePointEffect;*/

    private float fire_rate_weapon = 0.15f;
    //BT

    private IEnumerator SpawnBullet()
    {
        //
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet1.position = _listFirePoint[0].position;
        bullet1.rotation = Quaternion.Euler(0f, 0f, 0f);
        bullet1.GetComponent<Bullet>().Activate();
        Transform fire1 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        fire1.position = _listFirePoint[0].position;
        /*_listFirePointEffect[0].Play();*/
        AudioManager.Instance.PlaySound(AudioManager.Instance.fireSfx, null, 0.1f);
        
        //
        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet2.position = _listFirePoint[1].position;
        bullet2.rotation = Quaternion.Euler(0f, 0f, 0f);
        bullet2.GetComponent<Bullet>().Activate();
        Transform fire2 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        fire2.position = _listFirePoint[1].position;
        /*_listFirePointEffect[1].Play();*/
        AudioManager.Instance.PlaySound(AudioManager.Instance.fireSfx, null, 0.1f);

        if (GameManager.Instance.CurrentLevel < 3)
            yield break;
        
        //
        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet3.position = _listFirePoint[2].position;
        bullet3.rotation = Quaternion.Euler(0f, 0f, 1f);
        bullet3.GetComponent<Bullet>().Activate();
        Transform fire3 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        fire3.position = _listFirePoint[2].position;
        /*_listFirePointEffect[2].Play();*/
        AudioManager.Instance.PlaySound(AudioManager.Instance.fireSfx, null, 0.1f);
        
        //
        
        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet4.position = _listFirePoint[3].position;
        bullet4.rotation = Quaternion.Euler(0f, 0f, -1f);
        bullet4.GetComponent<Bullet>().Activate();
        Transform fire4 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        fire4.position = _listFirePoint[3].position;
        /*_listFirePointEffect[3].Play();*/
        AudioManager.Instance.PlaySound(AudioManager.Instance.fireSfx, null, 0.1f);
        
        //
        if (GameManager.Instance.CurrentLevel < 4)
            yield break;
        //
        Transform bullet5 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet5.position = _listFirePoint[4].position;
        bullet5.rotation = Quaternion.Euler(0f, 0f, 1f);
        bullet5.GetComponent<Bullet>().Activate();
        Transform fire5 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        fire5.position = _listFirePoint[4].position;
        /*AudioManager.Instance.PlaySound(AudioManager.Instance.fireSfx, null, 0.1f);*/
        
        //
        
        Transform bullet6 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet6.position = _listFirePoint[5].position;
        bullet6.rotation = Quaternion.Euler(0f, 0f, -1f);
        bullet6.GetComponent<Bullet>().Activate();
        Transform fire6 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        fire6.position = _listFirePoint[5].position;
        /*AudioManager.Instance.PlaySound(AudioManager.Instance.fireSfx, null, 0.1f);*/
        //
        if (GameManager.Instance.CurrentLevel < 5)
            yield break;
        //
        Transform bullet7 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet7.position = _listFirePoint[6].position;
        bullet7.rotation = Quaternion.Euler(0f, 0f, 1f);
        bullet7.GetComponent<Bullet>().Activate();
        Transform fire7 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        fire7.position = _listFirePoint[6].position;
        /*AudioManager.Instance.PlaySound(AudioManager.Instance.fireSfx, null, 0.1f);*/
        
        //
        
        Transform bullet8 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet);
        bullet8.position = _listFirePoint[7].position;
        bullet8.rotation = Quaternion.Euler(0f, 0f, -1f);
        bullet8.GetComponent<Bullet>().Activate();
        Transform fire8 = ObjectPutter.Instance.PutObject(SpawnerType.FirePointEffect);
        fire8.position = _listFirePoint[7].position;
        /*AudioManager.Instance.PlaySound(AudioManager.Instance.fireSfx, null, 0.1f);*/
        
        yield return null;
    }

    private IEnumerator StartFire()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            StartCoroutine(SpawnBullet());
            yield return new WaitForSeconds(fire_rate_weapon);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(StartFire());
    }
}