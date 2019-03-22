using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomomb : Enemy
{
    public override void Start()
    {

        base.Start();
    }
    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit!");
    }
}