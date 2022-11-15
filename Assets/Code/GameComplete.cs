using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComplete : MonoBehaviour
{
    public GameObject gameComplete;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        gameComplete.SetActive(true);
        Time.timeScale = 0;
    }
}
