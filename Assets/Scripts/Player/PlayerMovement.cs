using UnityEngine;

class PlayerMovement : MonoBehaviour
{
    CharacterController _characterController;
    Vector3 _playerVelocity;
    bool _isGrounded;

    [SerializeField]
    PlayerConfig _playerConfig;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        _isGrounded = _characterController.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _characterController.Move(_playerConfig.PlayerSpeed * Time.deltaTime * transform.TransformDirection(moveDirection));

        _playerVelocity.y += _playerConfig.Gravity * Time.deltaTime;
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -1.0f;
        }
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_playerConfig.JumpHeighy * -2.0f * _playerConfig.Gravity);
        }
    }
}
