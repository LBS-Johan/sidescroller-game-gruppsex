using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    KeyCode fireButton;

    [SerializeField]
    Vector2 fireDirection = Vector2.zero;

    [SerializeField]
    public float coolDown;

    [SerializeField]
    GameObject prefab;
    [SerializeField]
    Transform spawnLocation;


    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        while ((fireButton == KeyCode.None || Input.GetKey(fireButton)) && timer <= 0)
        {
            Vector2 pos = transform.position;
            if (spawnLocation != null)
            {
                pos = spawnLocation.position;
            }

            GameObject spawnedObject = Instantiate(prefab, pos, Quaternion.identity);

            Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = fireDirection;
            }


            timer = coolDown;
        }
    }

    public void PowerUpSmall(int lenght, int cooldown)
    {
        float oldCooldown = cooldown;

        coolDown = 0.05f;
    }
}
