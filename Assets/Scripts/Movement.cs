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
    private Animator _animator;
    [SerializeField]
    private Transform _bulletSpawn;

    private bool _isOnTheFloor;
    public bool IsFacingRight { get; private set; } = true;

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
        _animator.SetBool("RunningState", movement != 0);
        
        if (movement > 0 && !IsFacingRight || movement < 0 && IsFacingRight)
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
        _isOnTheFloor = !_isOnTheFloor && other.CompareTag("Ground") ? true : _isOnTheFloor;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
            _isOnTheFloor = false;
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        transform.Rotate(0, 180, 0);
    }
}