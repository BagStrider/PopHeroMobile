using UnityEngine;

public class EnemyMovement
{
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    public EnemyMovement(Transform transform, Rigidbody2D rigidbody)
    {
        _transform = transform;
        _rigidbody = rigidbody;
    }

    public void MoveTo(Vector3 direction)
    {
        _rigidbody.velocity = direction * Time.deltaTime * 100;
    }

    public void RotateTo(Vector3 direction)
    {
        _transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    public void StopMoving()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}