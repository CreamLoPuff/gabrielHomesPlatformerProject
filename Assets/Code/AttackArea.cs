using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 2;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<JumpEnemyAtacker>() != null)
        {
           HealthBar health = collider.GetComponent<HealthBar>();
            health.TakeDamage(damage);
        }
    }
}
