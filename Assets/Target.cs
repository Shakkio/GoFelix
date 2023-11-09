using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rec = ((RectTransform)transform);

        rec.position = new Vector3(
            rec.position.x, 
            rec.position.y,
            rec.position.z - Time.deltaTime * moveSpeed
        );
    }

    public void Hit(){
        Debug.Log("Hit");
        Destroy(this);
    }
}
