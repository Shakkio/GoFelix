using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    float speed;

    public bool isHolding;
    public ItemDetection itemDetection;
    bool pushed = false;

    public Sprite Fist;
    public Sprite HandOpen;
    public GameObject heldItem;
    public Demon demon;

    public float pushTimer = 0;
    public float maxPushTimer = 0.1f;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Movement();
        ItemInteraction();
    }


    void Movement()
    {
        if(!pushed)
        {
            Vector3 force = speed * new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
            rigidbody2D.AddForce(force, ForceMode2D.Impulse);
        }

        if(pushed)
        {
            pushTimer += Time.deltaTime;

            if(pushTimer > maxPushTimer)
            {
                pushTimer = 0;
                pushed = false;
            }
        }
    }

    void ItemInteraction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isHolding && itemDetection.possibleHeldItem.Count > 0)
                Grab();
            else if (isHolding)
                Release();
        }
    }

    void Grab()
    {
        isHolding = true;
        float minDistance = 9999999999999;
        GameObject chosen = null;
        for (int i = 0; i < itemDetection.possibleHeldItem.Count; i++)
        {
            var distance = Distance(transform.position, itemDetection.possibleHeldItem[i].transform.position);
            if(minDistance > distance)
            {
                minDistance = distance;
                chosen = itemDetection.possibleHeldItem[i];
            }
        }

        heldItem = chosen.transform.parent.gameObject;
        heldItem.AddComponent<ElementHolding>().SetHolder(this.gameObject);
        spriteRenderer.sprite = Fist;
    }

    void Release()
    {
        isHolding = false;
        if(heldItem)
        {
            demon.Eat(heldItem);
            Destroy(heldItem.GetComponent<ElementHolding>());
            heldItem = null;
        }

        spriteRenderer.sprite = HandOpen;
    }

    float Distance(Vector3 position1, Vector3 position2)
    {
        float distanceX = Mathf.Abs(position2.x - position1.x);
        float distanceY = Mathf.Abs(position2.y - position1.y);
        float distanceZ = Mathf.Abs(position2.z - position1.z);

        float manhattanDistance = distanceX + distanceY + distanceZ;
        return manhattanDistance;
    }

    public void Push(Vector2 direction, float force)
    {
        Debug.Log("Oi");
        rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
        pushed = true;
    }
}
