using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private static readonly int Jump = Animator.StringToHash("Jump");
    private Animator animator;


    private void Start()
    {
        // Cache the Animator component attached to CharacterArt //
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleAnimations();
    }
    
    private void HandleAnimations()
    {
        // Handle running and idling //
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }

        // Handle Jumping //
        if (Input.GetButtonDown("Jump"));
        {
            animator.SetTrigger("Jump");
        }
        
        // Handle wall jumping //
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("WallJump");
        }
    }
}

