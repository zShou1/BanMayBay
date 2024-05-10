using UnityEngine;

public class Boundary : MonoBehaviour
{
    //Boundary se Deactive Bullet khi dan bay vao
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("SupportShipBullet"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
