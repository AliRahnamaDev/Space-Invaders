using UnityEngine;

public class ShildScript : MonoBehaviour
{
    //Shild Script Manage Animations and Health
    Animator animator;
    public int Health = 6;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Health>=4) animator.SetInteger("Health",3);
        if(Health >=2 && Health<4) animator.SetInteger("Health",2);
        if(Health ==1) animator.SetInteger("Health",1);
        if(Health <= 0) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Playerbullets") || other.CompareTag("Enemybullets"))
        {
            Health--;
        }
    }
}
