using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private AudioSource audiosource;

    private float x, z;

    public enum State { Idle, Walking, Running, Jumping }
    public State estado = State.Idle;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        //Input.mousePosition

        if (Input.GetButtonDown(texts.FIRE_1))
        {
            Debug.Log("FIRE1");
            animator.SetTrigger(texts.ANIM_SHOOT);

        }
        if (Input.GetButtonDown(texts.FIRE_2))
        {
            Debug.Log("FIRE2");
            animator.SetTrigger(texts.ANIM_ATACK);

        }
    }

    private void TakeDamage()
    {
        animator.SetTrigger(texts.ANIM_TAKEDAMAGE);
    }
    private void Death()
    {

    }
}
