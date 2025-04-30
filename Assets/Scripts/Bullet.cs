using UnityEngine;

public class Bullet : MonoBehaviour
{
    //This script Manage Player bullet Movement Add score And Reduce EnemyCount
    public ScoreManager scoreManager;
    private Rigidbody2D rb;
    public static float speed=20;
    public float lifeTime;
    private GameManager gameManager;
    

    void Start()
    {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            rb = GetComponent<Rigidbody2D>();
            scoreManager = FindObjectOfType<ScoreManager>();
            Destroy(gameObject, lifeTime);
    }
    
    void Update()
    {
        rb.velocity = new Vector2(0, speed);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameManager.EnemyCount--;
            scoreManager.AddScore(10);
            Destroy(other.gameObject);
            Destroy(gameObject);     
        }

        if (other.CompareTag("Shild"))
        {
            Destroy(gameObject);
        }
    }

}
