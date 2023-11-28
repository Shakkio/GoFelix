 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class felixDarkness : MonoBehaviour
{
    public GameObject victoryScreen;
    public AudioClip clickSound;

    public float gameDuration = 7f;

    public SpriteRenderer flashLightRenderer;

    private void Start()
    {
        GoFelixManager.Instance.win = false;
    }



    private void Update()
    {
        Debug.Log(GoFelixManager.Instance.win);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        flashLightRenderer.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);

        bool mousePressed = Input.GetMouseButtonDown(0);

        if (mousePressed) 
        {
            //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

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
        GoFelixManager.Instance.win = true;
        victoryScreen.SetActive(true);
    }

}
