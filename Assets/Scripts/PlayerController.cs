using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public Transform bulletSpawnPoint;
    public GameObject Bullet1;
    public float moveSpeed = 10f;
    private float horizontal;
    private Rigidbody2D rb2d;
    public bool canshoot = true;
    public float FireRate;
    public float Health;
    public float MaxScore=1000;
    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.Space)&&canshoot)
        {
            StartCoroutine(DistaceBeetweenShots());
            GameObject bullet = Instantiate(Bullet1, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
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
        if (other.CompareTag("Enemybullets"))
        {
            Health--;
        }

        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(GameOver());
        }
        
    }
    
    //Coroutine For GameOver
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene(2);
    }
}
