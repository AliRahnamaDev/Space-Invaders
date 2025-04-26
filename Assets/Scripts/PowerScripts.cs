using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerScripts : MonoBehaviour
{
    private Transform transform;
    private SpriteRenderer spriteRenderer;
    private EnemyGroupController enemyGroupController;
    private Bullet bullet;
    private PlayerController player;
    public float abilityTimer;
    public int ability;
    public float BoostPlayerspeed;
    public float BoostFireRate;
    public float NerfEnemyspeed;
    public bool isBoosted;

    void Start()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ability = Random.Range(0, 81);
        player = FindObjectOfType<PlayerController>();
        bullet = FindObjectOfType<Bullet>();
        enemyGroupController = FindObjectOfType<EnemyGroupController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBoosted)
        {
            if (ability >= 0 && ability <= 32)
            {
                //speed
                StartCoroutine(PlayerSpeed());

            }
            
            if (ability >= 33 && ability <= 80)
            {
                //FireRate
                StartCoroutine(BoostPlayerFirerate());
            }

            if (ability >= 81 && ability <= 100)
            {
                
                StartCoroutine(NerfEnemySpeed());
            }
        }

        

    }

    IEnumerator PlayerSpeed()
    {
        float temp = player.moveSpeed;
        isBoosted = false;
        player.moveSpeed *= BoostPlayerspeed;
        yield return new WaitForSeconds(abilityTimer);
        player.moveSpeed = temp;
        
    }

    IEnumerator BoostPlayerFirerate()
    {
        float temp = player.FireRate;
        isBoosted = false;
        player.FireRate *= BoostFireRate;
        yield return new WaitForSeconds(abilityTimer);
        player.FireRate = temp;
        
    }

    IEnumerator NerfEnemySpeed()
    {
        float temp = enemyGroupController.moveSpeed;
        isBoosted = false;
        enemyGroupController.moveSpeed /= NerfEnemyspeed;
        yield return new WaitForSeconds(abilityTimer);
        enemyGroupController.moveSpeed = temp;
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Playerbullets"))
        {
            isBoosted = true;
            Destroy(other.gameObject);
            Destroy(gameObject,10);
            //spriteRenderer.enabled = false;
            transform.position = new Vector2(100,transform.position.y);
        }
    }
}
    

