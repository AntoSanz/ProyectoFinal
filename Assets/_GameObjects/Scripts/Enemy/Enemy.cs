using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    #region VAR
    public int damage;
    public int health;
    public int distanciaDeteccion;
    private Animator anim;
    private const float TIME_TO_DESTROY = 2f;
    [SerializeField] GameObject prefabEnemyDead;

    //Movimiento
    public Transform[] routePoints;
    private NavMeshAgent agente;
    private float playerDistance;
    //private Animator animator;
    public bool enemySleep;
    public float stopAcosoTime;

    #endregion

    #region VIRTUAL_FUNCTIONS
    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    public virtual void Start()
    {
        GetNewTarget();

            //health = health * GameManager.difficulty;
            //damage = damage * GameManager.difficulty;
 

        player = GameObject.Find("Player").GetComponent<Player>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        CheckChangeTarget();
        //TryDetect();
        if (enemySleep == false)
        {
            //CheckChangeTarget();
            TryDetect();
        }
        //if (enemySleep == true)
        //{
        //    anim.SetBool(texts.ANIM_ISWALKING, false);
        //}

    }

    public virtual void DoSpecialAction()
    {

    }

    private Player player;

    #endregion

    #region PUBLIC_FUNCTIONS

    public void TakeDamage(int _damage)
    {
        health = health - _damage;
        //Debug.Log("Vida enemigo: " + health);
        if (health > 0)
        {
            anim.SetTrigger(texts.ANIM_TAKING_DAMAGE);
        }
        else
        {
            Die();
        }
    }

    #endregion

    #region PRIVATE_FUNCTIONS
    private void DoDamageMelee(Collision _collision)
    {
        LookAtTarget(_collision);
        anim.SetTrigger(texts.ANIM_ATACK);
        _collision.gameObject.GetComponent<Player>().TakeDamage(damage);
    }

    private void LookAtTarget(Collision _collision)
    {
        transform.LookAt(_collision.gameObject.transform);
    }

    private void Move()
    {

    }

    private void Die()
    {
        Invoke("InstantiateParticleSystem", 2);
        //InstantiateParticleSystem();
        anim.SetTrigger(texts.ANIM_DIE);
        Destroy(this.gameObject, TIME_TO_DESTROY);
    }

    private void InstantiateParticleSystem()
    {
        if (prefabEnemyDead)
        {
            //Instantiate(prefabEnemyDead, this.transform.position, Quaternion.identity);
            Instantiate(prefabEnemyDead, this.transform.position + new Vector3(0, 1, 0), Quaternion.Euler(90, 0, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(texts.TAG_PLAYER))
        {
            DoDamageMelee(collision);
            IgnorePlayer();
            
            DoSpecialAction();
        }
    }
    #endregion

    #region MOVIMIENTO

    private void GetNewTarget()
    {
        anim.SetBool(texts.ANIM_ISWALKING, true);
        int newTarget = UnityEngine.Random.Range(0, routePoints.Length);
        GoTarget(newTarget);
    }

    private void GoTarget(int _target)
    {
        anim.SetBool(texts.ANIM_ISWALKING, true);
        agente.destination = routePoints[_target].position;
    }

    private void GoTarget(Vector3 _target)
    {
        anim.SetBool(texts.ANIM_ISWALKING, true);
        agente.destination = _target;
    }

    private void CheckChangeTarget()
    {

        if (transform.position == agente.destination)
        //if (agente.remainingDistance < agente.stoppingDistance)
        {
            GetNewTarget();
        }
    }

    private float GetPlayerDistance()
    {
        return Vector3.Distance(transform.position, player.gameObject.transform.position);
    }

    private void TryDetect()
    {
        playerDistance = GetPlayerDistance();
        if (playerDistance <= distanciaDeteccion)
        {
            GoTarget(player.gameObject.transform.position);
        }
    }
    private void IgnorePlayer()
    {
        GetNewTarget();
        IgnoreP1();
        Invoke("RestartIgnore", stopAcosoTime);
        ////distanciaDeteccion = 0;
        //enemySleep = true;
        //GetNewTarget();
        //StartCoroutine(IgnorePlayerTime());
        ////distanciaDeteccion = 10;
        //enemySleep = false;
    }
    private void IgnoreP1()
    {
        distanciaDeteccion = 0;
        GetNewTarget();
    }
    private void RestartIgnore()
    {
        distanciaDeteccion = 10;
    }
    IEnumerator IgnorePlayerTime()
    {
        print("START" + Time.time);
        yield return new WaitForSeconds(5);
        print("END" + Time.time);
    }
    #endregion
}
