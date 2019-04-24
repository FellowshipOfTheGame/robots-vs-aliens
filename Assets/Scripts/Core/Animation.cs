using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;
    public float animationTime = 0;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayTriggerAnimation(string name)
    {
        animator.SetTrigger(name);
    }
}
