using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class EnemyGroupController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed = 2f;
    public float moveDownAmount = 0.5f;
    public float LimitedArea = 8f;
    private bool movingRight = true;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (movingRight)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
        float leftMost = 10000f;
        float rightMost = -10000f;
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject enemy in enemies)
        {
            if (!enemy.activeInHierarchy) continue;

            float x = enemy.transform.position.x;
            if (x < leftMost) leftMost = x;
            if (x > rightMost) rightMost = x;
        }
        if (movingRight && rightMost >= LimitedArea)
        {
            MoveDown();
            movingRight = false;
        }
        else if (!movingRight && leftMost <= -LimitedArea)
        {
            MoveDown();
            movingRight = true;
        }

        
        if (movingRight && rightMost >= LimitedArea)
        {
            MoveDown();
            movingRight = false;
        }
        else if (!movingRight && leftMost <= -LimitedArea)
        {
            MoveDown();
            movingRight = true;
        }
    }
    private void MoveDown()
    {
        transform.position += Vector3.down * moveDownAmount;
    }
}
