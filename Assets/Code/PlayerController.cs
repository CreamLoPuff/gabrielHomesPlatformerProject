using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int maxLives = 3;
    public int currentLives;
    public GameObject GameOverText;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHelath(maxHealth);
        currentLives = maxLives;
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
            Time.timeScale = 1;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit(); 
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
        loseLife();
        GameOver();
    }


    public void loseLife()
    {
        print("loseLife");
        if (currentHealth <= 0)
        {
            currentLives -= 1;

            print("resetHealth");
            currentHealth = 10;
            healthBar.SetHealth(currentHealth);

        }
    }
    public void GameOver() 
    { 
        if (currentLives <= 0)
        {
            GameOverText.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
