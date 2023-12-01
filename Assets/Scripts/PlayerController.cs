using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement Movement => _movement;

    [SerializeField] private float _speed = 3f;

    private PlayerMovement _movement;
    private bool _canMove = true;
    private Joystick _joyStick;
    private Vector3 _joystickDirection = new Vector3();


    [Inject]
    private void Construct(FloatingJoystick playerJoystick)
    {
        _joyStick = playerJoystick;
        _movement = new PlayerMovement(GetComponent<Rigidbody2D>());
    }

    private void Update()
    {
        _joystickDirection = new Vector3(_joyStick.Horizontal, _joyStick.Vertical, 0).normalized;

        Rotate();
    }

    private void FixedUpdate()
    {
        Walk();
    }


    public void DisableMovementForSeconds(float seconds)
    {
        StartCoroutine(DisableMovement(seconds));
    }

    private void Walk()
    {
        if (!_canMove) return;

        _movement.MoveTo(_joystickDirection * _speed * Time.deltaTime);
    }

    private void Rotate()
    {
        if (!_canMove) return;

        if (_joystickDirection != Vector3.zero)
        {
            _movement.RotateTo(_joystickDirection);
        }
    }

    private IEnumerator DisableMovement(float seconds)
    {
        _canMove = false;

        yield return new WaitForSeconds(seconds);

        _canMove = true;
    }
}
