using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Item
{
    #region VAR
    [Header("Heart Config")]
    public int heal;
    #endregion

    #region OVERRIDE_FUNCTIONS
    public override void DoSpecialAction(Collider other)
    {
        Player playerScript = other.gameObject.GetComponent<Player>();
        if (playerScript.currentHp == GameManager.Max_hp_player)
        {
            return;
        }
        else
        {
            playerScript.GetHeal(heal);
            Kill();
        }
        base.DoSpecialAction(other);

    }
    public override void Kill()
    {
        base.Kill();
    }
    #endregion

    #region PRIVATE_FUNCIONS

    #endregion

    #region PUBLIC_FUNCIONS

    #endregion
}
