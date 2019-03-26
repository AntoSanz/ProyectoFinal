using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public int health;
    public int distanciaDeteccion;
    private Animator anim;
    private const float TIME_TO_DESTROY = 2f;
    [SerializeField] GameObject prefabEnemyDead;

    public virtual void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
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
    private void DoDamage(Collision collision)
    {
        anim.SetTrigger(texts.ANIM_ATACK);
        collision.gameObject.GetComponent<Player>().TakeDamage(damage);
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
            DoDamage(collision);
        }
    }

}
