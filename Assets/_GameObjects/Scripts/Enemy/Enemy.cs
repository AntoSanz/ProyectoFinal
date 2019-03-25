using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public int health;
    public int distanciaDeteccion;
    [SerializeField] GameObject prefabEnemyDead;

    public virtual void Start()
    {

    }
    private void TakeDamage(float _damage)
    {

    }
    private void DoDamage()
    {

    }
    private void Move()
    {

    }
    private void Die()
    {
        Instantiate(prefabEnemyDead, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerShoot"))
        {

            //            TakeDamage(damage);
            Debug.Log("Hit triger!");
        }
    }
}
