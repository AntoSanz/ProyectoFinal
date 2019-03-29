using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    #region VAR
    [Header("General")]
    public bool isAnimated = false;
    [Header("Rotate")]
    public bool isRotating = false;
    public Vector3 rotationAngle;
    public float rotationSpeed;

    [Header("Scale")]
    public bool isScaling = false;
    public Vector3 startScale;
    public Vector3 endScale;
    public float scaleSpeed;
    public float scaleRate;
    private bool scalingUp = true;
    private float scaleTimer;
    #endregion

    #region VIRTUAL_FUNCTIONS
    public virtual void Kill()
    {
        Destroy(this.gameObject);
    }

    public virtual void DoSpecialAction(Collider other) { }
    #endregion

    #region PRIVATE_FUNCTIONS
    private void Update()
    {
        if (isAnimated)
        {
            Rotate();
            Scale();
        }
    }

    private void Scale()
    {
        if (isScaling)
        {
            scaleTimer += Time.deltaTime;

            if (scalingUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
            }
            else if (!scalingUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
            }

            if (scaleTimer >= scaleRate)
            {
                if (scalingUp) { scalingUp = false; }
                else if (!scalingUp) { scalingUp = true; }
                scaleTimer = 0;
            }
        }
    }

    private void Rotate()
    {
        if (isRotating)
        {
            transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(texts.TAG_PLAYER))
        {
            DoSpecialAction(other);
            //Kill();
        }

    }
    #endregion

    #region PUBLIC_FUNCTIONS

    #endregion
}
