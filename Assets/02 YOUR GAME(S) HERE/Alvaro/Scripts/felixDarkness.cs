 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class felixDarkness : MonoBehaviour
{
    public float spotlightRadius = 5f;
    public LayerMask discoveredLayer; 
    public Material revealedFelix; 

    public SpriteRenderer flashLightRenderer;

    public GameObject gameOverImage; 
    public float timeLimit = 7f; 

    private float currentTime;
    private bool gameActive = true;

    void Start()
    {
        currentTime = timeLimit;
        gameOverImage.SetActive(false);
        UpdateUI();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        flashLightRenderer.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            DiscoverObjects();
        }

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            GoFelixManager.Instance.win = false;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        
    }

    void DiscoverObjects()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, spotlightRadius, discoveredLayer);

        foreach (Collider2D col in colliders)
        {
            SpriteRenderer spriteRenderer = col.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                print ("You found me!");
                GoFelixManager.Instance.win = true;
            }
            else
            {
                GoFelixManager.Instance.win = false;
            }
        }
    }
}
