using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    public Animator animator;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            Attack();
            attackArea.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("IsAttacking", false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool("IsAttacking", true);
        }
            
    if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }

        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }


    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }


}
