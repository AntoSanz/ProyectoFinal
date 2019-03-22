using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomomb : Enemy
{
    public override void Start()
    {
        this.transform.Translate(Vector3.right);
        base.Start();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit triger!");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit collision!");
    }
}