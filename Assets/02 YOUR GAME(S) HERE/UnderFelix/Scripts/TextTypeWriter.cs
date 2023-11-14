using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTypeWriter : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(TypeText());
        GetComponent<AudioSource>().Play();
    }
    
    IEnumerator TypeText()
    {
        string text = GetComponent<TextMeshProUGUI>().text;
        GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text)
        {
            GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(0.025f);
        }
    }
}
