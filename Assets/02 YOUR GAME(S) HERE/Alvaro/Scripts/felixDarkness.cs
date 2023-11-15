using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class felixDarkness : MonoBehaviour
{
    public float spotlightRadius = 5f;
    public LayerMask discoveredLayer; // Layer for objects to be discovered
    public Material revealedFelix; // Material to reveal discovered objects

    private SpriteRenderer spotlightRenderer;

    void Start()
    {
        // Create a spotlight sprite for the cursor
        GameObject spotlight = new GameObject("Spotlight");
        spotlightRenderer = spotlight.AddComponent<SpriteRenderer>();
        spotlightRenderer.sprite = Resources.Load<Sprite>("SpotlightSprite"); // Replace with your spotlight sprite
        spotlightRenderer.color = Color.white; // Adjust the color as needed
    }

    void Update()
    {
        // Update spotlight position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spotlightRenderer.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);

        // Discover objects when the player clicks
        if (Input.GetMouseButtonDown(0))
        {
            DiscoverObjects();
        }
    }

    void DiscoverObjects()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, spotlightRadius, discoveredLayer);

        foreach (Collider2D col in colliders)
        {
            SpriteRenderer spriteRenderer = col.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.material = revealedFelix;
            }
        }
    }
}
