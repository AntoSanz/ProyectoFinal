using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator animator;
    private AudioSource audiosource;
    private NavMeshAgent agent;
    [SerializeField] FirePoint firePoint;
    [SerializeField] Slider sliderhp;

    private float x, y, z;
    private const int MAX_HP = 100;
    private int currentHp;

    public enum State { Idle, Walking, Running, Jumping }
    public State estado = State.Idle;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        currentHp = 100;
    }

    private void Update()
    {
        NavMeshMovement();
        ManageAtack();
        DebugAnimations();
        ManageMovementAnimation();
    }

    /// <summary>
    /// Gestiona las animaciones de andar e idle.
    /// </summary>
    private void ManageMovementAnimation()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || Mathf.Abs(agent.velocity.sqrMagnitude) < float.Epsilon)
            {
                //walking = false;
                estado = State.Idle;
                animator.SetBool(texts.ANIM_ISWALKING, false);
            }
        }
        else
        {
            //walking = true;
            estado = State.Walking;
            animator.SetBool(texts.ANIM_ISWALKING, true);
        }
    }

    /// <summary>
    /// Gestiona el movimiento para cuando hacemos click derecho con el ratón.
    /// Cambia el estado actual a State.Walking.
    /// </summary>
    private void NavMeshMovement()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool(texts.ANIM_ISWALKING, true);
            estado = State.Walking;

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }

    /// <summary>
    /// Ejecuta la función de ataque con el click izquierdo del ratón.
    /// </summary>
    private void ManageAtack()
    {
        if (Input.GetButtonDown(texts.FIRE_1))
        {
            StopMove();
            Debug.Log("FIRE1 RANGE");
            animator.SetTrigger(texts.ANIM_SHOOT);
            firePoint.Shoot();
        }
    }

    /// <summary>
    /// Para el desplazamiento del player y cambia su estado a Idle.
    /// </summary>
    private void StopMove()
    {
        estado = State.Idle;
        animator.SetBool(texts.ANIM_ISWALKING, false);
        agent.destination = transform.position;
    }

    /// <summary>
    /// Gestiona el daño recibido y lo representa en la barra de vida. Además hace la animación de recibir daño y si la vida llega a cero (0), ejecuta el método de morir.
    /// </summary>
    /// <param name="_damage"></param>
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
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("FIRE2 MELEE");
            animator.SetTrigger(texts.ANIM_ATACK);
        }
    }
}
