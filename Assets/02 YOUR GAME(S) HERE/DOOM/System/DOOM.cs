
using UnityEngine;
using Unity;
using System.Collections;
using FMOD;

public class DOOM : MonoBehaviour
{
    public static DOOM Instance;

    public float gracePeriod = 0.5f;
    public FelixController felixController;
    public RectTransform gameOver;
    public RectTransform cursor;
    public Canvas canvas;
    public Transform targetParent;
    public GameObject target;
    public GameObject flyEnemies;

    public float maxTimeToPlay = 7f;
    public float timePlayed = 0;
    //
    public AnimationCurve walkSpawnRateChange;
    float walkSpawnRate;
    float walkWaitTime = 0;

    //
    public AnimationCurve flySpawnRateChange;
    float flySpawnRate;
    float flyWaitTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(!Instance)
            Instance = this;

        Cursor.visible = false;
        Invoke("GoFelix", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCursor();

        if (gracePeriod < 0){
            SpawnDemons();
            SpawnSouls();
        }
        else 
            gracePeriod -= Time.deltaTime;

        timePlayed += Time.deltaTime;
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
    
    void SpawnDemons(){
        if(walkWaitTime <= 0 && walkSpawnRate > 0){
            var go = Instantiate(target, new Vector3(Random.Range(-5.0f, 5.0f), 1.25f, 15.0f), Quaternion.identity, targetParent);

            Vector3 targetPostition = new Vector3( transform.position.x, 
                                       go.transform.position.y, 
                                       transform.position.z ) ;

            go.transform.LookAt(targetPostition);

            walkWaitTime = walkSpawnRate;
        } else 
            walkWaitTime -= Time.deltaTime;
        
        float t = timePlayed/maxTimeToPlay;
        walkSpawnRate = walkSpawnRateChange.Evaluate(t);
    }
    
    void SpawnSouls(){
        if(flyWaitTime <= 0 && flySpawnRate > 0){
            var go = Instantiate(flyEnemies, new Vector3(Random.Range(-7.0f, 7.0f), 20f, 20.0f), Quaternion.identity, targetParent);
            go.transform.LookAt(transform);
            flyWaitTime = flySpawnRate;
        } else 
            flyWaitTime -= Time.deltaTime;
        
        float t = timePlayed/maxTimeToPlay;
        flySpawnRate = flySpawnRateChange.Evaluate(t);
    }

    public void Die(){
        gameOver.gameObject.SetActive(true);
        felixController.gameObject.SetActive(false);
        canvas.enabled = false;
        GoFelixManager.Instance.win = false;
    }

    void GoFelix(){
        GoFelixManager.Instance.win = true;
    }
}
