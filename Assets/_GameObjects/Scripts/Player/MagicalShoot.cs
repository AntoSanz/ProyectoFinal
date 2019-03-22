using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalShoot : MonoBehaviour
{
    float timeToDestroy = 2.20f;
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

}
