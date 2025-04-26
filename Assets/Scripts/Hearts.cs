using UnityEngine;

public class Hearts : MonoBehaviour
{
    //Player Hearts GameObject Animation Controller
    private Animator animator;
    public PlayerController player;
    void Start()
    {
       animator = GetComponent<Animator>(); 
    }

    
    void Update()
    {
       if(player.Health==5) animator.SetInteger("Health",5); 
       if(player.Health==4) animator.SetInteger("Health",4);
       if(player.Health==3) animator.SetInteger("Health",3);
       if(player.Health==2) animator.SetInteger("Health",2);
       if(player.Health==1) animator.SetInteger("Health",1);
       if(player.Health==0) animator.SetInteger("Health",0);
    }
}
