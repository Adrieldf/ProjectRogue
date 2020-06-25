using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _speed;
    private bool _isOnTheFloor;

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
        _rigidbody.velocity = new Vector2(movement * Time.deltaTime * _speed, 0);
    }

    void CheckJump()
    {
        var spaceButton = Input.GetButtonDown("Jump");

        if (spaceButton && _isOnTheFloor)
            _rigidbody.AddForce(new Vector2(0, 300));
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
}