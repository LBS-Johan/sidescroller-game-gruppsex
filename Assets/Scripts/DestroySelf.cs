using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void DestroyMySelf()
    {
        Destroy(gameObject);
    }
}
