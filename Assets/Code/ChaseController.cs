using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseController : MonoBehaviour
{
    public FlyingEnemy[] enemyArray;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            foreach (FlyingEnemy enemy in enemyArray)
            {
                enemy.chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            foreach (FlyingEnemy enemy in enemyArray)
            {
                enemy.chase = false;
            }
        }
    }
}
