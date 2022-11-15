using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GameObject NextLevelText;
    public void OnTriggerEnter2D(Collider2D collider)
    {
            NextLevelText.SetActive(true);
    }
}
