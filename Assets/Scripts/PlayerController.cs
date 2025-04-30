using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private MusicShotManager musicShotManager;
    private Animator animator;
    public Transform bulletSpawnPoint;
    public GameObject Bullet;
    public float moveSpeed = 10f;
    private float horizontal;
    private Rigidbody2D rb2d;
    public bool canshoot = true;
    public float FireRate;
    public float Health;
    public float MaxScore=1000;
    public bool IsShooting = false;
    public bool CanHit=true;
    void Start()
    {
        //Access to script of MusicShotManager
        musicShotManager = FindObjectOfType<MusicShotManager>();
        //Player Rb and animator component
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
      
    }
    void Update()
    {
        if (Health < 1)
        {
            //Lose
            animator.SetBool("distroy", true);
            Destroy(gameObject,1f);
            SceneManager.LoadScene(2);
        }
        Move();
        shooting();
       
        if (IsShooting && FireRate >=3.01 )
        {
            musicShotManager.OnPlayerShoot();
            //Play Music When it is in FireRate boost Mode
        }
    }

    //Player FireRate
    IEnumerator DistaceBeetweenShots()
    {
        canshoot = false;
        yield return new WaitForSeconds(1/FireRate);
        canshoot = true;
    }
    
    //player shoot Mechanic
    private void shooting()
    {
        if (Input.GetKey(KeyCode.Space)&&canshoot)
        {
            StartCoroutine(DistaceBeetweenShots());
            GameObject bullet = Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            IsShooting=true;
        }
        else
        {
            IsShooting=false;
        }
    }
    
    //Player Movement Mechanic
    //Movement With access to Rb and velocity parameter  
    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontal * moveSpeed, rb2d.velocity.y);
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemybullets") && CanHit)
        {
            Health--;
            StartCoroutine(distaceBeetweenHits());
        }

        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(GameOver());
        }
        
    }
    
    //Coroutine For GameOver
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2);
    }

    IEnumerator distaceBeetweenHits()
    {
        CanHit = false;
        yield return new WaitForSeconds(1.5f);
        CanHit = true;
    }
}
