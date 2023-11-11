using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Target : MonoBehaviour
{
    public float moveSpeed;
    public VisualEffect vfx;
    public SpriteRenderer spriteRenderer;
    
    float deathTime = 0.0f;
    public float deathTimer = 1.5f;

    AudioSource audio;
    public AudioClip[] clips;

    bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = clips[Random.Range(0, clips.Count())];
        audio.loop = false;
        audio.PlayOneShot(audio.clip);
    }

    // Update is called once per frame
    void Update()
    {
        Transform rec= transform;

        if(dead){
            audio.Stop();

            rec= spriteRenderer.transform;
            rec.position = new Vector3(
                rec.position.x, 
                rec.position.y + Time.deltaTime * moveSpeed * Random.Range(0.5f, 2.5f),
                rec.position.z + Time.deltaTime * moveSpeed * 2.5f
            );
            
            Transform vfRec= vfx.transform;
            vfRec.position = new Vector3(
                vfRec.position.x, 
                vfRec.position.y,
                vfRec.position.z - Time.deltaTime * moveSpeed
            );
            
            return;
        }

        rec.position += rec.forward * Time.deltaTime * moveSpeed;
    }

    public void Hit(){
        dead = true;
        vfx.transform.SetParent(null);
        //GetComponent<GraphicRaycaster>().enabled = false;

        Debug.Log("Hit");
        StartCoroutine(Kill());
    }

    IEnumerator Kill(){
        vfx.Play();

        var rec = spriteRenderer.transform;

        while(deathTime <= deathTimer){
            float t = deathTime / deathTimer;

            rec.Rotate( new Vector3(
                    (1.0f - t) * 90.0f,
                    (1.0f - t) * 35.0f,
                    (1.0f - t) * 35.0f
                )
            );
            spriteRenderer.color = new Color(1.0f - t / 2.0f, 0, 0);

            deathTime += Time.deltaTime;
            yield return null;
        }

        //Destroy(this.gameObject);
        yield return null;
    }
}
