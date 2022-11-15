using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Delete : MonoBehaviour
{
    public GameObject levelStarText;
    public GameObject level1;
    public GameObject levelClearText;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        levelStarText.SetActive(true);
        levelClearText.SetActive(false);
        Destroy(level1);
    }
}
