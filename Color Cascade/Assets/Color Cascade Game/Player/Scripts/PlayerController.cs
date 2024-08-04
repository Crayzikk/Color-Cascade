using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Joystick joystick;

    private Vector2 moveVelocity;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private PlayerAnimationManager playerAnimationManager;

    private bool isGrounded;
    private bool canMove;
    private bool canJump;
    private bool isRinning;
    private bool isJumping;

    [SerializeField] private LayerMask platformLayer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    private void Start() 
    {
        rigidbody = GetComponent<Rigidbody2D>();    
        playerAnimationManager = GetComponent<PlayerAnimationManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        if(!EndLevel.levelComplete)
        {
            CheckGround();

            isRinning = joystick.Horizontal != 0;

            if(((joystick.Vertical >= 0.60 && joystick.Vertical < 0.85) || (joystick.Vertical <= -0.60 && joystick.Vertical > -0.85)) && isGrounded)
            {
                canJump = true;
                canMove = true;
            }
            else if(joystick.Vertical > 0.85 && isGrounded)
            {
                canJump = true;
                canMove = false;
            }
            else
            {
                canJump = false;
                canMove = true;
            }

            if(isRinning && !isJumping)
            {
                playerAnimationManager.PlayWalk();
            }
            else if(isJumping && !isGrounded)
            {
                playerAnimationManager.PlayJump();
            }
            else if(isJumping && isGrounded)
            {
                playerAnimationManager.PlayLand();
                isJumping = false;
            }
            else
            {
                playerAnimationManager.PlayIddle();
            }
        }
    }

    private void FixedUpdate() 
    {
        if(canMove)
            MovePlayer();

        if(canJump)
            JumpPlayer();
    }

    private void MovePlayer()
    {
        Flip();
        rigidbody.velocity = new Vector2(joystick.Horizontal * speed, rigidbody.velocity.y);
    }

    private void JumpPlayer()
    {
        isJumping = true;
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
    }

    private void CheckGround()
    {
        isGrounded = 
        (
            Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer)
            ||
            Physics2D.OverlapCircle(groundCheck.position, 0.2f, platformLayer)
        );
    }

    private void Flip()
    {
        spriteRenderer.flipX = joystick.Horizontal < 0;
    }
}
