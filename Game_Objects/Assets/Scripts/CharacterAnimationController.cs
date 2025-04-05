using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update //
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame //
    void Update()
    {
        HandleAnimations();
    }
    
    private void HandleAnimations()
    {
        // Triggers the jump anim //
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        
        // Trigger hit anim //
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("Hit");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
            
        // Triggers fall anim //
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Fall");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
            
        // Handle running anim //
        if (Input.GetButton("Horizontal"))
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        
        // Handle wall jumping //
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("WallJump");
        }
    }
}

