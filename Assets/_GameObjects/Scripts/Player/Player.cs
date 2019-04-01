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
    //[SerializeField] GameObject sliderhp;
    private GameObject sliderhp;
    private float reloadTimeCount;
    public float timeBetweenShoots;
    private float x, y, z;
    //private const int MAX_HP = 100;
    public int currentHp;
    public enum State { Idle, Walking, Running, Jumping }
    public State estado = State.Idle;

    public bool canAtack;

    #region PRIVATE_FUNCTIONS
    private void Awake()
    {
        canAtack = true;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        reloadTimeCount = timeBetweenShoots;
        currentHp = 100;
        sliderhp = GameObject.FindGameObjectWithTag("HpPlayerSlider");
    }

    private void Update()
    {
        reloadTimeCount = reloadTimeCount + Time.deltaTime;
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
        if (canAtack == true && Input.GetButtonDown(texts.FIRE_1) && reloadTimeCount >= timeBetweenShoots)
        {
            StopMove();
            LookAtClick();
            Debug.Log("FIRE1 RANGE");
            animator.SetTrigger(texts.ANIM_SHOOT);
            bool isShooted = firePoint.Shoot();
            if (isShooted)
            {
                reloadTimeCount = 0;
            }

        }
    }

    private void LookAtClick()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {

            agent.transform.LookAt(new Vector3(hit.point.x, firePoint.transform.position.y, hit.point.z));
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

    private void UpdateHealBar(int currentHP)
    {
        sliderhp.GetComponent<Slider>().value = currentHp;
        //sliderhp.value = currentHp;
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void TakeDamage(int _damage)
    {
        currentHp = currentHp - _damage;
        UpdateHealBar(currentHp);
        if (currentHp > 0)
        {
            animator.SetTrigger(texts.ANIM_TAKEDAMAGE);
        }
        else Die();
    }

    public void GetHeal(int _heal)
    {
        currentHp = currentHp + _heal;
        currentHp = Mathf.Min(currentHp, GameManager.Max_hp_player);
        //sliderhp.value = currentHp;
        UpdateHealBar(currentHp);
        //currentHp = currentHp + _heal;
    }
    #endregion

}
