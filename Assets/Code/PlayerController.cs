using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 10.0f;
    public float jumpforce = 10;
    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollider2d;
    [SerializeField][Range(0, 1)] float LerpConstant;
    [SerializeField] private LayerMask platformsLayerMask;
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    private int maxLives = 3;
    private static int currentLives;
    public GameObject GameOverText;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHelath(maxHealth);
        


    }
  
    private void Awake()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
   
        float xMove = Input.GetAxisRaw("Horizontal");
        Vector3 newPosition = transform.position;
        newPosition.x += xMove * Time.deltaTime * runSpeed;
        transform.position = newPosition;   

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage(2);
        }
        else if (collision.gameObject.tag == "gap")
        {
            TakeDamage(5);
        }
    }

    private bool isGrounded()
    {  
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
 

    public void die()
    {
        if (currentHealth == 0)
        {
            currentLives -=1;
        }
        else if (currentLives == 0)
        {
            GameOverText.SetActive(true);
            Time.timeScale = 0;
        }
    }

}