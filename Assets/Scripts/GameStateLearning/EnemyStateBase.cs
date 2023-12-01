public abstract class EnemyStateBase : IState
{
    protected readonly Enemy _enemy;
    protected readonly Player _player;

    public EnemyStateBase(Enemy enemy, Player player)
    {
        _enemy = enemy;
        _player = player;
    }

    public abstract void Enter();

    public abstract void Exit();
}
