using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomomb : Enemy
{
    public override void Start()
    {
        //QUITAR CUANDO ESTE EN FUNCIONAMIENTO EL NAVMESH
        this.transform.Translate(Vector3.right);
        //QUITAR CUANDO ESTE EN FUNCIONAMIENTO EL NAVMESH

        base.Start();
    }
    public override void DoSpecialAction()
    {
        //EXPLOSION
        base.DoSpecialAction();
    }
}