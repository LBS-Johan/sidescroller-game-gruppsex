using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f;

    private float spriteWidth;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

        // Calculate width of sprite in world units
        spriteWidth = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        // If the sprite has moved left by its full width, recycle it
        if (transform.position.x <= startPosition.x - spriteWidth)
        {
            transform.position = startPosition;
        }
    }
}
