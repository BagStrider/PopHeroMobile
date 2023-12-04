using UnityEngine;
using Zenject;

public class Enemy : Entity , IContactInteractable
{
    public EnemyMovement Movement => _movement;

    [SerializeField] private HealthBehaviour _healthBeh;

    private EnemyMovement _movement;
    private EnemyStateMachine _stateMachine;
    private Player _player;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        _movement = new EnemyMovement(transform, GetComponent<Rigidbody2D>());
        _stateMachine = new EnemyStateMachine(this, _player);
        _stateMachine.Enter<EnemyIdleState>();

        _healthBeh.OnHealthOver += Dies;
    }

    private void FixedUpdate()
    {
        _stateMachine.Update();
    }

    public void Interact()
    {
        _healthBeh.TakeHealth(1f);
    }
}
