using UnityEngine;

public class ControllerTest : MonoBehaviour
{
    [SerializeField] private Joystick _joyStick;

    [SerializeField] private float _speed = 3f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Rotate();
    }

    private void FixedUpdate()
    {
        Walk();
    }

    private void Walk()
    {
        Vector2 joystickRot = new Vector3(_joyStick.Horizontal, _joyStick.Vertical, 0).normalized;

        _rb.velocity = joystickRot * _speed * Time.deltaTime;
    }

    private void Rotate()
    {
        Vector2 joystickRot = new Vector3(_joyStick.Horizontal, _joyStick.Vertical, 0).normalized;

        if (joystickRot != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, joystickRot);
        }
    }
}
