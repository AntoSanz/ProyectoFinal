using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalShoot : MonoBehaviour
{
    #region VAR
    float timeToDestroy = 2.20f;
    public Animator colliderAnim;
    public int damage;
    #endregion

    #region PRIVATE_FUNCIONS
    void Start()
    {
        colliderAnim.SetBool(texts.START, true);
        Destroy(this.gameObject, timeToDestroy);
    }
    #endregion

}
