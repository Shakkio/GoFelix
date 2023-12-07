using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    Animator animator;
    public GameDirector gameDirector;
    public List<GameObject> screenItems;
    public Transform PlaceToInstatiate;

    bool isReady;
    bool isDone;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(isReady == false)
        {
            AnimationCheck();
        }
        else if(isReady && !isDone)
        {
            int id = gameDirector.GetItemId();
            Instantiate(screenItems[id], PlaceToInstatiate);
            isDone = true;
        }
        else if(isDone)
        {
            Destroy(this);
        }

    }

    void AnimationCheck()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ScreenTurnOn") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            isReady = true;
        }
    }
}
