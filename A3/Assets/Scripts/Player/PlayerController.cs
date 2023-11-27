using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator playerAnimator;

    private Vector3 direction;
    private int currentLane = 1;
    private int laneWidth = 1;
    private float gravity = -20f;

    public float moveSpeed;
    public float jumpForce;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        direction.z = moveSpeed;
        direction.y += gravity * Time.deltaTime;

        playerAnimator.SetFloat("MoveSpeed", moveSpeed);

        if(characterController.isGrounded)
        {
            playerAnimator.SetBool("Grounded", true);
        }
        else
        {
            playerAnimator.SetBool("Grounded", false);
        }

        SwipeMovement();
    }

    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime);
    }

    public void SwipeMovement()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLane--;
            if(currentLane == -1)
            {
                currentLane = 0;
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLane++;
            if(currentLane == 3)
            {
                currentLane = 2;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(currentLane == 0)
        {
            targetPosition += Vector3.left * laneWidth;
        }
        else if(currentLane == 2)
        {
            targetPosition += Vector3.right * laneWidth;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 60 * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }
}
