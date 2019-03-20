using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator animator;
    private AudioSource audiosource;
    [SerializeField] Slider sliderhp;

    private float x, y, z;
    private const int MAX_HP = 100;
    private int currentHp;

    public enum State { Idle, Walking, Running, Jumping }
    public State estado = State.Idle;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHp = 100;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

        }

        ManageAtack();
        DebugAnimations();
    }

    private void ManageAtack()
    {
        if (Input.GetButtonDown(texts.FIRE_1))
        {
            Debug.Log("FIRE1 RANGE");
            animator.SetTrigger(texts.ANIM_SHOOT);

        }
        if (Input.GetButtonDown(texts.FIRE_2))
        {
            Debug.Log("FIRE2 MELEE");
            animator.SetTrigger(texts.ANIM_ATACK);
        }
    }

    private void DebugAnimations()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Die();
        }
    }

    private void TakeDamage(int _damage)
    {
        Debug.Log("TakeDamage.");
        Debug.Log("HP: " + currentHp);

        currentHp = currentHp - _damage;
        sliderhp.value = currentHp;
        if (currentHp > 0)
        {
            animator.SetTrigger(texts.ANIM_TAKEDAMAGE);
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Die");
        animator.SetTrigger(texts.ANIM_DIE);
    }

    //Cuando el player se mueve, el mago mira hacia donde se está moviendo
    //Cuando el player hace click del ratón, el mago mira hacia donde ha hecho click el jugador y hace la habilidad asignada hacia ahí y vuelve a mirar ¿hacia donde lo estaba haciendo o se queda mirando a donde ataca?
}
