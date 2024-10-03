using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderBehaviour : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void CharacterIdle()
    {
        if (gameObject.tag == "HGDefender")
        {
            animator.CrossFade("idle_guard_hg", 0.2f);
        }
        else if(gameObject.tag == "ARDefender")
        {
            animator.CrossFade("idle_guard_ar", 0.2f);
        }
        else if (gameObject.tag == "SGDefender")
        {
            animator.CrossFade("idle_guard_sg", 0.2f);
        }
        else if (gameObject.tag == "SRDefender")
        {
            animator.CrossFade("idle_guard_sr", 0.2f);
        }
    }
    public void CharacterShoot()
    {
        if (gameObject.tag == "HGDefender")
        {
            animator.CrossFade("shoot_single_hg", 0.01f);
        }
        else if (gameObject.tag == "ARDefender")
        {
            animator.CrossFade("shoot_single_ar", 0.01f);
        }
        else if (gameObject.tag == "SGDefender")
        {
            animator.CrossFade("gunMiddleShoot_single_sg", 0.01f);
        }
        else if (gameObject.tag == "SRDefender")
        {
            animator.CrossFade("shoot_single_sr", 0.01f);
        }
    }
    public void CharacterIdleShoot()
    {
        if (gameObject.tag == "HGDefender")
        {
            animator.CrossFade("idle_shoot_hg", 0.2f);
        }
        else if (gameObject.tag == "ARDefender")
        {
            animator.CrossFade("idle_shoot_ar", 0.2f);
        }
        else if (gameObject.tag == "SGDefender")
        {
            animator.CrossFade("reload_gunMiddleShoot_sg", 0.2f);
        }        
        else if (gameObject.tag == "SRDefender")
        {
            animator.CrossFade("idle_shoot_sr", 0.2f);
        }
    }
}
