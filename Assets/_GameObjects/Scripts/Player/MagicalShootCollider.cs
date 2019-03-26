using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalShootCollider : MonoBehaviour
{
    [SerializeField] MagicalShoot MagicalShoot;
    public int damage;

    private void Start()
    {
        damage = MagicalShoot.damage;
    }
    public void DestroyCollider()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(texts.TAG_ENEMY))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
