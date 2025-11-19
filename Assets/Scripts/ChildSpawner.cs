using UnityEngine;

public class ChildSpawner : MonoBehaviour
{
    [SerializeField]
    KeyCode fireButton;

    [SerializeField]
    float coolDown;

    [SerializeField]
    GameObject prefab;
    [SerializeField]
    Transform spawnLocation;
    [SerializeField]
    GameObject parent;


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

            GameObject spawnedObject = Instantiate(prefab, pos, Quaternion.identity, parent.transform);


            timer = coolDown;
        }
    }

    public void PowerUpSmall(int lenght, int cooldown)
    {
        float oldCooldown = cooldown;

        coolDown = 0.1f;
        fireButton = KeyCode.None;
    }
}