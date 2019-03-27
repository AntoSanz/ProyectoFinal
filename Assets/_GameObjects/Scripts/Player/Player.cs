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

    #region PRIVATE_FUNCTIONS
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

    private void NavMeshMovement()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //LookAtClick();
            animator.SetBool(texts.ANIM_ISWALKING, true);
            estado = State.Walking;

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }

    private void ManageAtack()
    {
        if (Input.GetButtonDown(texts.FIRE_1))
        {
            StopMove();
            LookAtClick();
            Debug.Log("FIRE1 RANGE");
            animator.SetTrigger(texts.ANIM_SHOOT);
            firePoint.Shoot();
        }
    }

    private void LookAtClick()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {

            agent.transform.LookAt(new Vector3(hit.point.x, 0, hit.point.z));
        }
    }

    private void StopMove()
    {
        estado = State.Idle;
        animator.SetBool(texts.ANIM_ISWALKING, false);
        agent.destination = transform.position;
    }

    private void Die()
    {
        Debug.Log("Die");
        animator.SetTrigger(texts.ANIM_DIE);
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
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("FIRE2 MELEE");
            animator.SetTrigger(texts.ANIM_ATACK);
        }
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void TakeDamage(int _damage)
    {
        currentHp = currentHp - _damage;
        sliderhp.value = currentHp;
        if (currentHp > 0)
        {
            animator.SetTrigger(texts.ANIM_TAKEDAMAGE);
        }
        else Die();
    }
    #endregion

}
