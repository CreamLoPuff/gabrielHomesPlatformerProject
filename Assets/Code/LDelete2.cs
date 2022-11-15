using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LDelete2 : MonoBehaviour
{
    public GameObject levelStarText;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        levelStarText.SetActive(false);
    }
}
