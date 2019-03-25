using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalShootCollider : MonoBehaviour
{
    public void DestroyCollider()
    {
        Destroy(this.gameObject);
    }
}
