using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    public int damage = 50;
    GameObject player;
    //Xu ly va cham voi Particle Trigger Module
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        gameObject.GetComponent<ParticleSystem>().trigger.AddCollider(player.transform);
    }
    private void OnParticleTrigger()
    {
        ParticleSystem ps = transform.GetComponent<ParticleSystem>();
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
        for(int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            enter[i] = p;
            player.GetComponent<HealthPlayer>().DecreaHealth(damage);
        }
        for(int i = 0; i < numExit; i++)
        {
            ParticleSystem.Particle p = exit[i];
            exit[i] = p;
        }
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    }
}
