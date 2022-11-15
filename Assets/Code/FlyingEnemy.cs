using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    private GameObject player;
    public Transform startingPoint;
    public bool chase = false; 
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }
    
    void Update()
    {
        if (player == null)
            return;

        if (chase == true)
            Chase();    
        else
            ReturnStartPoint();
        flip();
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed = Time.deltaTime);
    }
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed = Time.deltaTime);
    }

    private void flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);  
    }
}
