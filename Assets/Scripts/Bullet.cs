using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage = 2f;

    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector3 direction, float speed)
    {
        _rigidbody.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageTakeable>(out var damagable))
        {
            damagable.TakeDamage(_damage);
        }
    }
}