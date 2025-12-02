using UnityEngine;

public class Upgrader : MonoBehaviour
{
    [SerializeField] type Type;
    [SerializeField] int Health_Boost;
    [SerializeField] float Firerate_Boost;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var statKeeper = other.GetComponent<StatKeeper>();

        if (statKeeper == null )
        {
            return;
        }

        if (Type == type.Health)
        {
            statKeeper.extraHealth += Health_Boost;
            statKeeper.updateStats("health");
            return;
        }
        else if (Type == type.Firerate)
        {
            statKeeper.firerate += Firerate_Boost;
            statKeeper.updateStats("firerate");
            return;
        }
        
    }

    public enum type
    {
        Health,
        Firerate
    }
}
