using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class JumpAndShift : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sprintMultiplier = 1.5f;

    [Header("Jumping")]
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private int maxJumps = 2;

    [Header("References")]
    [SerializeField] private Transform orientation; // ќбъект, определ€ющий направление (обычно тело игрока)

    private CharacterController controller;
    private Vector3 velocity;
    private int jumpCount = 0;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground check
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            jumpCount = 0; // —брос прыжков на земле
        }

        // Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveDirection = orientation.TransformDirection(inputDirection);

        float finalSpeed = isSprinting ? moveSpeed * sprintMultiplier : moveSpeed;

        controller.Move(finalSpeed * Time.deltaTime * moveDirection);

        // Jumping
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            velocity.y = jumpForce;
            jumpCount++;
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}


