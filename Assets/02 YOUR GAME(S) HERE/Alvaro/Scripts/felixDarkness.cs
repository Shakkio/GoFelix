 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class felixDarkness : MonoBehaviour
{
    public GameObject victoryScreen;
    public AudioClip clickSound;
    public float gameDuration = 7f;

    public SpriteRenderer flashLightRenderer;

    private bool hasWon = false;
    private float timer = 0f;

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        flashLightRenderer.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);

        timer += Time.deltaTime;

        if (timer >= gameDuration && !hasWon)
        {
            LoseGame();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Victory"))
                {
                    WinGame();
                }
                else if (hit.collider.CompareTag("Clickable"))
                {
                    AudioSource.PlayClipAtPoint(clickSound, hit.transform.position);
                }
            }
        }
    }

    private void WinGame()
    {
        print("I won!");
        hasWon = true;
        victoryScreen.SetActive(true);
        GoFelixManager.Instance.win = true;
    }

    private void LoseGame()
    {
        print("I lost!");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //GoFelixManager.Instance.win = false;
    }
}
