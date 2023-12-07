using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaner : MonoBehaviour
{
    public GameDirector gameDirector;

    public float timer = 0.0f;
    public float maxTimer = 0.3f;

    public float maxForce;
    public float maxParabola;


    public float minForce;
    public float minParabola;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimerCheck();

    }

    void TimerCheck()
    {
        if (timer < maxTimer)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            InstantiateStuff();
        }
    }

    void InstantiateStuff()
    {
        float force = Random.Range(0, maxForce);
        float parabola = Random.Range(0, maxParabola);
        GameObject toGo = gameDirector.GetChosenGameObject();
        Vector2 direction = new Vector2(force, parabola);
        Instantiate(toGo, transform).GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse); ;
        
    }

}
