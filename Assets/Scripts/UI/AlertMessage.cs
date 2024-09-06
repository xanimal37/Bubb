using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertMessage : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        FadeOut();
    }
    public void FadeOut()
    {
        if (animator != null)
        {
            animator.Play("FadeOut");
        }
    }

   
}
