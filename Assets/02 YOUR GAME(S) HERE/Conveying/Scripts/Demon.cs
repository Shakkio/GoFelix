using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    Animator animator;
    public Hand hand;
    BoxCollider2D box;
    int eatingId;

    float eatingTimer = 0;
    float eatingTimerMax = 1f;

    public float hunger = 3;

    bool interactionOver;
    public GameDirector gameDirector;

    AudioSource audioSource;
    public AudioClip eatSound;
    bool up = false;
    public AudioClip doneSound;
    public AudioClip upSound;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.Play("DemonAppear");
        box = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("DemonAppear") && !up)
        {
            up = true;
            audioSource.PlayOneShot(upSound);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("DemonPrepare"))
        {
            if(hand.isHolding == false)
            {
                box.enabled = false;
                box.enabled = true;
            }

        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("DemonUp"))
        {
            if (hand.isHolding == true)
            {
                box.enabled = false;
                box.enabled = true;
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("DemonEat"))
        {
            eatingTimer += Time.deltaTime;

            if(eatingTimer > eatingTimerMax)
            {
                bool good = CheckId();
                if (hunger <= 0 && good)
                {
                    interactionOver = true;
                    animator.Play("DemonGood");
                    audioSource.PlayOneShot(doneSound);
                }
                else if (good)
                {
                    animator.Play("DemonUp");
                    hunger--;
                }
                eatingTimer = 0;
            }
        }
    }

    public bool CheckId()
    {
        int chosenId = gameDirector.GetItemId();
        if(chosenId == eatingId)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Eat(GameObject item)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("DemonPrepare"))
        {
            audioSource.PlayOneShot(eatSound);

            for (int i = 0; i < gameDirector.convetabletees.Count; i++)
            {
                if(item.GetComponent<SpriteRenderer>().sprite.name == gameDirector.convetabletees[i].GetComponent<SpriteRenderer>().sprite.name)
                {
                    eatingId = i;
                    Debug.Log("eat: " + eatingId);
                    break;
                }
            }
            Destroy(item);
            animator.Play("DemonEat");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(interactionOver == false)
        {
            if (collision.gameObject.transform.parent != null)
            {
                if (collision.gameObject.transform.parent.name == "Hand")
                {
                    hand = collision.gameObject.transform.parent.gameObject.GetComponent<Hand>();
                    if (hand.isHolding == true)
                    {
                        animator.Play("DemonPrepare");
                    }
                    else
                    {
                        animator.Play("DemonUp");
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (interactionOver == false)
        {
            if (collision.gameObject.transform.parent != null)
            {
                if (collision.gameObject.transform.parent.name == "Hand")
                {
                    animator.Play("DemonUp");
                }
            }
        }
    }


}
