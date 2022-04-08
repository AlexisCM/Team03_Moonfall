using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _speed; // Movement speed

    private PlayerInput _playerInputs;
    private InputAction _movement;

    private Vector3 _moveDirection;
    private Vector3 _velocity;
    private bool _isGrounded;

    private float _gravity = -9.81f;
    private float _groundDistance = 0.4f;

    // Start is called before the first frame update
    void Awake() {
        _playerInputs = new PlayerInput();
        _movement = _playerInputs.Player.Movement;
    }

    private void OnEnable() {
        _movement.Enable();
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void Move() {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (_isGrounded && _velocity.y < 0) {
            _velocity.y = -2f;
        }

        _moveDirection = new Vector3(_movement.ReadValue<Vector2>().x, 0,
            _movement.ReadValue<Vector2>().y);
        _moveDirection = _mainCamera.TransformDirection(_moveDirection);

        _controller.Move(_moveDirection * _speed * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime); // g * t^2
    }
}
