using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class bross : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D rig;
    public float speed;
    private Bross boss;
    public float attackRange = 3f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        rig = animator.GetComponent<Rigidbody2D>();

        boss = animator.GetComponent<Bross>();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //boss.LookAtPlayer();
       
        Vector2 target = new Vector2(player.position.x, rig.position.y);
        Vector2 newPos =  Vector2.MoveTowards(rig.position, target, speed * Time.fixedDeltaTime);
       
        rig.MovePosition(newPos);

        if (Vector2.Distance(player.position, rig.position) <= attackRange)
        {
            animator.SetTrigger("attack");
        }
    }

   
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      animator.ResetTrigger("attack");
   }
   
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
    
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
    }
}

internal class Bross
{
}
