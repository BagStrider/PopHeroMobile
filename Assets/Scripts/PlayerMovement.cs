using UnityEngine;

public class PlayerMovement
{
    private Rigidbody2D _rigidbody;

    public PlayerMovement(Rigidbody2D rigidbody)
    {
        _rigidbody = rigidbody;
    }

    public void AddForce(Vector3 direction)
    {
        _rigidbody.AddForce(direction, ForceMode2D.Impulse);
    }

    public void MoveTo(Vector3 direction)
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(direction, ForceMode2D.Impulse);
    }

    public void RotateTo(Vector3 direction)
    {
        _rigidbody.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }
}
