using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAnimation : MonoBehaviour
{
    private Animation bossAnim;
    public GameObject wingLeft;
    public GameObject wingRight;
    public GameObject _shield;

    bool check = false;
    public GameObject waveBullet2;
    public GameObject waveBullet1;
    public GameObject waveGunLeft;
    public GameObject waveGunRight;
    public GameObject handGunLeft;
    public GameObject handGunRight;




    // Start is called before the first frame update
    private void Awake()
    {
        bossAnim = gameObject.GetComponent<Animation>();
        _shield.SetActive(false);
        waveGunLeft.GetComponent<WaveGunState1>().enabled = true;
        waveGunRight.GetComponent<WaveGunState1>().enabled = true;
        waveGunLeft.GetComponent<WaveGunState2>().enabled = false;
        waveGunLeft.GetComponent<Collider2D>().enabled = false;
        
        waveGunRight.GetComponent<WaveGunState2>().enabled = false;
        waveGunRight.GetComponent<Collider2D>().enabled = false;
        waveBullet2.GetComponent<WaveBullet2>().enabled = false;
        waveBullet1.GetComponent<WaveBullet>().enabled = true;
        handGunLeft.GetComponent<Collider2D>().enabled = false;
        handGunRight.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<ActiveBossHealth>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(wingLeft.active==false && wingRight.active == false)
        {
            deActiveWaveGunPhase1();
            _shield.SetActive(true);
            this.GetComponent<Animator>().enabled=true;
            
        }

        if (check)
        {
            _shield.SetActive(false);
            
            waveGunLeft.GetComponent<WaveGunState2>().enabled = true;
            waveGunLeft.GetComponent<Collider2D>().enabled = true;
            waveBullet2.GetComponent<WaveBullet2>().enabled = true;
            
            waveGunRight.GetComponent<WaveGunState2>().enabled = true;
            waveGunRight.GetComponent<Collider2D>().enabled = true;
            waveBullet1.GetComponent<WaveBullet>().enabled = false;
            handGunLeft.GetComponent<Collider2D>().enabled = true;
            handGunRight.GetComponent<Collider2D>().enabled = true;
        }

    }
    public void disableAnimation()
    {
        this.GetComponent<Animator>().enabled = false;
        check = true;
        gameObject.GetComponent<ActiveBossHealth>().enabled = true;
    }
    public void deActiveWaveGunPhase1()
    {
        waveGunLeft.GetComponent<WaveGunState1>().enabled = false;
        waveGunRight.GetComponent<WaveGunState1>().enabled = false;

    }
}
