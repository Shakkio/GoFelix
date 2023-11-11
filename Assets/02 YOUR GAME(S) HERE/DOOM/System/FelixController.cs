using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.VFX;

public class FelixController : MonoBehaviour
{
    public AudioSource audioSource;
    public VisualEffect vfx;
    public Transform body;
    public CinemachineVirtualCamera vc;
    public Light2D spot;
    Coroutine lighting;
    public float spotDuration = 0.1f;

    public AnimationCurve lightCurve;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown(0) ){ 
            var shake = vc.GetComponent<CinemachineImpulseSource>();
            shake.GenerateImpulse();
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

            if ( Physics.Raycast (ray,out hit, 100.0f)) {
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                var tar = hit.transform.GetComponent<Target>();
                tar.Hit();

                hit.collider.enabled = false;
            }

            audioSource.time = .1f;
            audioSource.PlayOneShot(audioSource.clip);
            
            vfx.Play();

            if(lighting != null)
                StopCoroutine(lighting);

            lighting = StartCoroutine(Light());
        }

        body.localEulerAngles = new UnityEngine.Vector3(
            0,
            Mathf.Sin(Time.time * 5.0f ) * 2.0f,
            0
        );
    }

    IEnumerator Light(){
        float spotTime = 0;
        while(spotTime <= spotDuration)
        {
            float t = spotTime/spotDuration;

            spot.intensity = lightCurve.Evaluate(t);

            spotTime += Time.deltaTime;
            yield return null;
        }

        spot.intensity = 0;
        yield return null;
    }
}
