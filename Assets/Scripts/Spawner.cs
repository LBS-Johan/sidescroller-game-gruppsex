using System.Collections;
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
    [SerializeField]
    AudioClip shootSound;

    AudioSource audioSource;

    private IEnumerable coroutine;
    float timer = 0;

    public StatKeeper statKeeper;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        statKeeper = GetComponentInParent<StatKeeper>();
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

            if (audioSource != null && shootSound != null)
            {
                audioSource.PlayOneShot(shootSound);
            }


            timer = coolDown;
        }
    }

    public void PowerUpFirerateStarter(float lenght, float cooldown)
    {
        StartCoroutine(PowerUpFirerate(lenght, cooldown));
    }

    public IEnumerator PowerUpFirerate(float lenght, float cooldown2)
    {
        float oldCooldown = coolDown;
        coolDown = cooldown2;

        yield return new WaitForSeconds(lenght);

        coolDown = oldCooldown;
    }
}
