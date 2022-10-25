using System.ComponentModel;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    [ReadOnly(true)]
    protected int health = 100;

    protected int currentHealth;

    [SerializeField]
    protected Transform healthbar;

    private void Awake()
    {
        currentHealth = health;
    }

    public virtual void DecreaHealth(int bulletDamage)
    {
    }
}
