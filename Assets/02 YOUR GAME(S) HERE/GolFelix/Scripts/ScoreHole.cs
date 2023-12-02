using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class ScoreHole : MonoBehaviour
{
    public VisualEffect vfx;
    public AudioSource sfx;
    public AudioSource nicecSfx;
    
    public Image img;
    public Image darkImg;
    
    private void Start()
    {
        GoFelixManager.Instance.win = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Debug.Log("You win!");
            GoFelixManager.Instance.win = true;
            vfx.Play();
            sfx.Play();
            StartCoroutine(NiceShot());
        }
    }

    public IEnumerator NiceShot(){
        yield return new WaitForSeconds(0.5f);
        nicecSfx.Play();

        float elapsed = 0f;
        float duration = 0.5f;

        while(elapsed <= duration){
            float t = elapsed / duration;

            img.color       = new Color(1.0f,1.0f,1.0f, t);
            darkImg.color   = new Color(0f,0f,0f, t);

            elapsed += Time.deltaTime;
            yield return null;
        }
        
        img.color       = new Color(1.0f,1.0f,1.0f, 1.0f);
        darkImg.color   = new Color(0f,0f,0f, 1.0f);

        yield return null;
    }
}
