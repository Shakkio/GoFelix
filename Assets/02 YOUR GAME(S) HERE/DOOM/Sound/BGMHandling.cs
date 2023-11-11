using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMHandling : MonoBehaviour
{
    AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        bgm.time = 6.25f;
    }
}
