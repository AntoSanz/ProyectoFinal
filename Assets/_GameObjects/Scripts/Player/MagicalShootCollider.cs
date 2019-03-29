using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalShootCollider : MonoBehaviour
{
    #region VAR
    [SerializeField] MagicalShoot MagicalShoot;
    public int damage;
    #endregion

    #region PRIVATE_FUNCIONS
    private void Start()
    {
        damage = MagicalShoot.damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(texts.TAG_ENEMY))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    #endregion

    #region PUBLIC_FUNCIONS
    public void DestroyCollider()
    {
        Destroy(this.gameObject);
    }
    #endregion



}
