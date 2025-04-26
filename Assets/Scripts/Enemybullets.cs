using System;
using UnityEngine;

public class Enemybullets : MonoBehaviour
{
    Rigidbody2D rb2d;
    public   float speed = 5f;
    public float lifeTime = 3f; 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime); 
        
    }
    void Update()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x,-speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shild"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

