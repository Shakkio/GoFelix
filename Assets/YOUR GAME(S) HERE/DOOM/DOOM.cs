
using UnityEngine;
using Unity;

public class DOOM : MonoBehaviour
{
    public RectTransform cursor;
    public Canvas canvas;
    public Transform targetParent;
    public GameObject target;
    public float spawnRate = 1.5f;
    float waitTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCursor();

        if(waitTime <= 0){
            Instantiate(target, new Vector3(Random.Range(-5.0f, 5.0f), 1.25f, 7.5f), Quaternion.identity, targetParent);
            waitTime = spawnRate;
        } else 
            waitTime -= Time.deltaTime;
    }

    void UpdateCursor(){
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, 
            Input.mousePosition, 
            canvas.worldCamera, 
            out position);

        cursor.localPosition = position;
    }
}
