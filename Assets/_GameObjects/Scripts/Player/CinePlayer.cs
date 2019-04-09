using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinePlayer : MonoBehaviour
{
    private Animator animator;
    public GameObject prefabLevitateCast;
    public GameObject prefabLevitateEnd;
    public Transform particlesGeneratorTransform;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isLevitate", true);
        Instantiate(prefabLevitateCast, particlesGeneratorTransform.position, particlesGeneratorTransform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
