using UnityEngine;


class InputManager : MonoBehaviour
{
    private InputSystem _playerInput;
    private PlayerMovement _playerMovement;
    private PlayerLook _playerLook;
    internal InputSystem.GameplayActions Gameplay;


    void Awake()
    {
        _playerInput = new InputSystem();
        Gameplay = _playerInput.Gameplay;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerLook = GetComponent<PlayerLook>();
        Gameplay.Jump.performed += ctx => _playerMovement.Jump();
    }


    void FixedUpdate()
    {
        if (_playerMovement)
            _playerMovement.ProcessMove(Gameplay.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        if(_playerLook)
           _playerLook.ProcessLook(Gameplay.Look.ReadValue<Vector2>());
    }
    void OnEnable() 
    {
        Gameplay.Enable();
    }


    void OnDisable()
    {
        Gameplay.Disable();
    }
}
