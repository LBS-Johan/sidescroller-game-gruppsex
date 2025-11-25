using Unity.Mathematics;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float powerUpLenght;
    public float cooldown;

    public string[] strings;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (cooldown <= 0) { Debug.Log("fuck you"); return; }
        PlayerHealth phealth = collider.gameObject.GetComponent<PlayerHealth>();
        if (phealth == null)
        {
            int2 int2 = 0; //av simon den coola
            return;
        }

        Spawner bulletspawn = collider.gameObject.GetComponent<Spawner>();

        bulletspawn.PowerUpFirerateStarter(powerUpLenght, cooldown);

        Destroy(gameObject);
    }
}