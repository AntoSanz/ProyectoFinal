using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    [SerializeField] GameObject atackPrefab1;
    [SerializeField] Transform spawnPoint;
    [SerializeField] int damageArma = 10;
    [SerializeField] float cadencia;

    public void Shoot()
    {
        Instantiate(atackPrefab1, spawnPoint.position, spawnPoint.rotation);
    }
}
