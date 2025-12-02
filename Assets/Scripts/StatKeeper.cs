using UnityEngine;

public class StatKeeper : MonoBehaviour
{
    public float firerate = 0f;
    public int extraHealth = 0;

    Spawner spawner;
    PlayerHealth playerHP;

    public void updateStats(string what)
    {
        spawner = GetComponentInParent<Spawner>();
        playerHP = GetComponentInParent<PlayerHealth>();

        if (what == "firerate")
        {
            spawner.coolDown -= firerate;
        }
        if (what == "health")
        {
            playerHP.maxHealth += extraHealth;
        }
    }
}
