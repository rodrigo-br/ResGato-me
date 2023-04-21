using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    Animator myAnimator;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        myAnimator.SetInteger("Index", Random.Range(0, 9));
    }
}
