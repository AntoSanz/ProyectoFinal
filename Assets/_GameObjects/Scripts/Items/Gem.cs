using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Item
{
    #region VAR
    private bool destroyItem = false;
    #endregion

    #region OVERRIDE_FUNCTIONS
    public override void DoSpecialAction(Collider other)
    {
        if (true)
        {
            base.DoSpecialAction(other);
            GameManager.AddPoints(10);
            Kill();
        }

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