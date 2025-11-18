using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerHealth phealth = collider.gameObject.GetComponent<PlayerHealth>();
        if (phealth == null)
        {
            return;
        }

        Spawner bulletspawn = collider.gameObject.GetComponent<Spawner>();

        bulletspawn.PowerUpSmall(20, 0);

        Destroy(gameObject);
    }
}
