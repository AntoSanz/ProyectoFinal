using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    #region VAR
    [SerializeField] GameObject atackPrefab1;
    [SerializeField] Transform spawnPoint;
    [SerializeField] int damageArma = 10;
    [SerializeField] float cadencia;
    //private float reload;
    #endregion

    #region PRIVATE_FUNCTIONS
    private void Update()
    {
        //reload = reload + Time.deltaTime;
    }
    #endregion

    #region PUBLIC_FUNCIONS
    public bool Shoot()
    {
        //if (reload >= 1)
        //{
        //reload = 0;
        Instantiate(atackPrefab1, spawnPoint.position, spawnPoint.rotation);
        return true;
        //}
    }
    #endregion

}
