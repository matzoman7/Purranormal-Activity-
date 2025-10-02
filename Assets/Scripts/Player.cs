using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent (typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 3f;
    public float sprintSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;


    private void Start()
    {
        controller = GetComponent<CharacterController> ();  
    }

    private void Update()
    {
        //                                  MOVEMENT CODE START
        // -----------------------------------------------------------------------------------
        //Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;//Keeps player grounded (wip)
        }
        //Movement Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Sprinting
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        //Moving the Player
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move* speed * Time.deltaTime);
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //Applying Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        // -----------------------------------------------------------------------------------
        //                                  MOVEMENT CODE END
    }
}
