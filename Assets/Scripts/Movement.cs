using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float jumpVelocity = 25;
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Animator animator;

    private bool _isOnTheFloor;
    private bool _isFacingRight = true;

    void Update()
    {
        CheckJump();
    }

    void FixedUpdate()
    {
        GetHorizontalMovement();
    }

    void GetHorizontalMovement()
    {
        var movement = Input.GetAxis("Horizontal");
        animator.SetBool("RunningState", movement != 0);
        
        if (movement > 0 && !_isFacingRight || movement < 0 && _isFacingRight)
            Flip();

        _rigidbody.velocity = new Vector2(movement * Time.deltaTime * _speed, _rigidbody.velocity.y);
    }

    void CheckJump()
    {
        var spaceButton = Input.GetButtonDown("Jump");

        if (spaceButton && _isOnTheFloor)
        {
            _rigidbody.velocity = Vector2.up * jumpVelocity;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _isOnTheFloor = other.CompareTag("Ground");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
            _isOnTheFloor = false;
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}