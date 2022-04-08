using UnityEngine;

public class MouseLook : MonoBehaviour {
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _sensitivity = 300f;

    private float _xRotation = 0f;
    private float _yRotation = 0f;

    private Vector2 _mouseMovement;

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        _mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        _yRotation += _mouseMovement.x * _sensitivity * Time.deltaTime;
        _xRotation -= _mouseMovement.y * _sensitivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Slerp(transform.rotation, 
            Quaternion.Euler(_xRotation, _yRotation, 0f), 0.5f);
    }
}
