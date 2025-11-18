using UnityEngine;

public class BulletDespawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > Camera.main.orthographicSize * Camera.main.aspect || transform.position.x < -Camera.main.orthographicSize * Camera.main.aspect) { Destroy(gameObject); }
        if (transform.position.y > Camera.main.orthographicSize || transform.position.y < -Camera.main.orthographicSize) { Destroy(gameObject); }
    }
}
