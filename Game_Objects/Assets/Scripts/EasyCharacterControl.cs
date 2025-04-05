using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EasyCharacterControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;


    private CharacterController controller;
    private Vector3 velocity;
    private Transform thisTransform;
    private AudioSource sound;

    private void Start()
    {
        //Cache references to components //
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnXAxis();
    }


    private void MoveCharacter()
    {
        // Horizontal movement //
        var moveInput = Input.GetAxis("Horizontal");
        var move = new Vector3(moveInput, 0f, 0f) * (moveSpeed * Time.deltaTime);
        controller.Move(move);

        // Jumping movement //
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            sound.Play();
        }
    }

    private void ApplyGravity()
    {
        // Apply gravity when not grounded //
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            // Reset velocity when grounded //
            velocity.y = 0f;
        }

        // Apply the velocity to the controller //
        controller.Move(velocity * Time.deltaTime);
    }

    private void KeepCharacterOnXAxis()
    {
        // Keep character on the same spot in z axis //
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            Destroy(other.gameObject);
        }
    }
}