using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private bool enableSpeedUp = false;
    [SerializeField] private float speedUp = 5.0f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private bool enableJump = false;
    [SerializeField] private Animator characterAnimator = null;

    private CharacterController characterController = null;
    private Vector3 moveDirection = Vector3.zero;
    public float originSpeed { get; private set; }
    #region Input IDs
    private const string SIDE_MOVES = "Horizontal";
    private const string FORWARD_BACKWARD_MOVES = "Vertical";
    private int isMovingID = Animator.StringToHash("isMoving");
    private int isJumpingID = Animator.StringToHash("isJumping");
    #endregion Input IDs

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        if (characterAnimator == null)
            characterAnimator = transform.GetChild(0).GetChild(0).GetComponent<Animator>();

        originSpeed = moveSpeed;
    }


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis(SIDE_MOVES);
        float verticalInput = Input.GetAxis(FORWARD_BACKWARD_MOVES);

        characterAnimator.SetFloat("X", horizontalInput);
        characterAnimator.SetFloat("Y", verticalInput);

        if (enableSpeedUp)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed = speedUp;
                characterAnimator.speed = speedUp / moveSpeed;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = originSpeed;
                characterAnimator.speed = 1;
            }
        }
            
        if (characterController.isGrounded)
        {
            moveDirection = (transform.right * horizontalInput + transform.forward * verticalInput) * moveSpeed;

            if (enableJump)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    characterAnimator.SetBool(isMovingID, false);
                    characterAnimator.SetBool(isJumpingID, true);
                    moveDirection.y += jumpForce;
                }
            }
        }
        moveDirection.y += gravity * Time.deltaTime;
        characterAnimator.SetBool(isJumpingID, false);
        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void EnableJump(bool enable)
    {
        enableJump = enable;
    }   
    
    public void EnableSpeedUp(bool enable)
    {
        enableSpeedUp = enable;
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
}


