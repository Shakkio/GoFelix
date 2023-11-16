 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class felixDarkness : MonoBehaviour
{
    public float spotlightRadius = 5f;
    public LayerMask discoveredLayer; 
    public Material revealedFelix; 

    public SpriteRenderer flashLightRenderer;

    void Start()
    {

    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        flashLightRenderer.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);

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
                print ("You found me!");
            }
        }
    }
}
