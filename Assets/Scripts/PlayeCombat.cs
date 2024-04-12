using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayeCombat : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){

            Attack();
        }
    }

    void Attack(){
        //play attack animation
        animator.SetTrigger("Attack");

    }
}
