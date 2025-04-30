using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerScripts : MonoBehaviour
{
    private MusicShotManager musicShotManager;
    private Transform transform;
    private EnemyGroupController enemyGroupController;
    private PlayerController player;
    public float abilityTimer;
    private int ability;
    public float BoostPlayerspeed;
    public float BoostFireRate;
    public float NerfEnemyspeed;
    public bool isBoosted;
     

    void Start()
    {
        musicShotManager = FindObjectOfType<MusicShotManager>();
        transform = GetComponent<Transform>();
        ability = Random.Range(0, 101);
        player = FindObjectOfType<PlayerController>();
        enemyGroupController = FindObjectOfType<EnemyGroupController>();
    }

    
    void Update()
    {
        if (isBoosted)
        {
            if (ability >= 0 && ability <= 32)
            {
                //Boost speed 
                StartCoroutine(PlayerSpeed());

            }
            
            if (ability >= 32 && ability <= 80 )
            {
                //Boost FireRate
                StartCoroutine(BoostPlayerFirerate());
               

            }
            

            if (ability >= 81 && ability <= 100)
            {
                //Nerf Enimies Movement
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
            //If we destroy game object as soon as it hits the bullet the Boosts and Nerfs
            //wouldn't disappear after abilityTimer so We take it to another pos.
            transform.position = new Vector2(100,transform.position.y);
        }
    }
}