using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public TextManager textmanager;
    public static int score;
    private Rigidbody2D rb;
    public static float speed=20;
    public float lifeTime;
    private GameManager gameManager;
    

    void Start()
    {
            
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            rb = GetComponent<Rigidbody2D>();
            textmanager = FindObjectOfType<TextManager>();
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
            textmanager.AddScore(10);
            Destroy(other.gameObject);
            Destroy(gameObject);     
        }

        if (other.CompareTag("Shild"))
        {
            Destroy(gameObject);
        }
    }
//df
}
