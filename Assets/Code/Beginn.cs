using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Beginn : MonoBehaviour
{
    public GameObject BeginText;
    public GameObject BeginClearText;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        BeginText.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        BeginClearText.SetActive(false);
    }
}