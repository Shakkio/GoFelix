using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public List<GameObject> convetabletees;
    GameObject chosenGameObject;
    public int chosenId;




    private void Awake()
    {
        RandomizeChosen();
    }

    public int GetItemId()
    {
        return chosenId;
    }

    void RandomizeChosen()
    {
        int random = Random.Range(0, convetabletees.Count);
        chosenGameObject = convetabletees[random];
        chosenId = random;
    }

    public GameObject GetChosenGameObject()
    {
        int random = Random.Range(0, convetabletees.Count);
        chosenGameObject = convetabletees[random];

        return chosenGameObject;
    }
}
