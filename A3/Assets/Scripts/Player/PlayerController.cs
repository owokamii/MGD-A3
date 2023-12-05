using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator playerAnimator;

    private Transform playerPos;
    private Vector3 direction;
    private int currentLane = 1;
    private int laneWidth = 1;
    private float gravity = -20f;

    public float moveSpeed;
    public float jumpForce;
    [HideInInspector] public bool isJumping = false;

    public GameObject gameOverUI;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        direction.z = moveSpeed;
        direction.y += gravity * Time.deltaTime;

        playerAnimator.SetFloat("MoveSpeed", moveSpeed);

        if (characterController.isGrounded)
        {
            playerAnimator.SetBool("Grounded", true);
            isJumping = false;
        }
        else
        {
            playerAnimator.SetBool("Grounded", false);
            isJumping = true;
        }

        CheckLane();
    }

    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime);
    }

    public void CheckLane()
    {
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (currentLane == 0)
        {
            targetPosition += Vector3.left * laneWidth;
        }
        else if (currentLane == 2)
        {
            targetPosition += Vector3.right * laneWidth;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 60 * Time.fixedDeltaTime);
        characterController.center = characterController.center;
    }

    public void Jump()
    {
        direction.y = jumpForce;
    }

    public void Land()
    {
        direction.y = -jumpForce;
    }

    public void MoveLeft()
    {
        currentLane--;
        if (currentLane == -1)
        {
            currentLane = 0;
        }
    }

    public void MoveRight()
    {
        currentLane++;
        if (currentLane == 3)
        {
            currentLane = 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}