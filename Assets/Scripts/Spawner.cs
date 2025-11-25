using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    KeyCode fireButton;

    [SerializeField]
    Vector2 fireDirection = Vector2.zero;

    [SerializeField]
    float coolDown;

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

        while ((fireButton == KeyCode.None || Input.GetKeyDown(fireButton)) && timer <= 0)
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

    public void PowerUpFirerateStarter(float lenght, float cooldown)
    {
        Start(PowerUpFirerate(lenght, cooldown));
    }

    public IEnumerable PowerUpFirerate(float lenght, float cooldown)
    {
        float oldCooldown = coolDown;
        coolDown = coolDown;

        yield return new WaitForSeconds(lenght);

        coolDown = oldCooldown;
    }
}
