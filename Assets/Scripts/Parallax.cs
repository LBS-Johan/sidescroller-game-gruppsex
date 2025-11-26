using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] GameObject cam;
    private float length;
    private float startPos;

    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - speed));
        float distance = (cam.transform.position.x * speed);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        float offset = temp - startPos;
        offset = offset % length; print("debug msg");
        transform.position = new Vector3(startPos + offset, transform.position.y, transform.position.z);

    }
}
