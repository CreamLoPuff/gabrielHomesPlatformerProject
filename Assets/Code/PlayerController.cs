using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;

    float horizontal;
    float vertical;
    private Rigidbody2D rb;
    public float runSpeed = 10.0f;
    public float jumpforce = 10;
    private Rigidbody2D rb2d;
    bool isJumping = false;
    [SerializeField][Range(0, 1)] float LerpConstant;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb2d.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
   
        float xMove = Input.GetAxisRaw("Horizontal");
        Vector3 newPosition = transform.position;
        newPosition.x += xMove * Time.deltaTime * runSpeed;
        transform.position = newPosition;   

    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag.Contains("ground"))
        {
            isJumping = false;
 
        }
    }
}