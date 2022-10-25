using UnityEngine;

public class MiniGun : BaseEnemy
{
    [SerializeField]
    private Transform healthBar;

    [SerializeField]
    private Transform currentHealthBar;
    private int damage = 10;
    public override void DecreaHealth(int bulletDamage)
    {
        if (!healthBar.gameObject.activeSelf)
        {
            healthBar.gameObject.SetActive(true);
            currentHealthBar.localScale = Vector3.one;
        }
        base.DecreaHealth(bulletDamage);
        if (currentHealth > 0)
        {
            currentHealthBar.localScale = new Vector3((float)currentHealth / health, 1f, 1f);
        }
    }

    private void FixRotation()
    {
        healthBar.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<HealthPlayer>().DecreaHealth(damage);
        }
    }
    private void Update()
    {
        FixRotation();
    }
}
