using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Joystick joystick;

    private Vector2 moveVelocity;
    private Rigidbody2D rigidbody;
    private bool isGrounded;
    private bool canMove;
    private bool canJump;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    private void Start() 
    {
        rigidbody = GetComponent<Rigidbody2D>();    
    }

    private void Update() 
    {
        CheckGround();

        if((joystick.Vertical >= 0.80 && joystick.Vertical < 0.90) && isGrounded)
        {
            canJump = true;
            canMove = true;
        }
        else if(joystick.Vertical > 0.90 && isGrounded)
        {
            canJump = true;
            canMove = false;
        }
        else
        {
            canJump = false;
            canMove = true;
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
        rigidbody.velocity = new Vector2(joystick.Horizontal * speed, rigidbody.velocity.y);
    }

    private void JumpPlayer()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
