using System.Collections.Generic;

public class EnemyStateMachine : StateMachineBase<EnemyStateBase>
{
    public EnemyStateBase CurrentState => _activeState;

    private Enemy _enemy;
    private Player _player;
    private AreaObjectChecker _areaObjectChecker;


    public EnemyStateMachine(Enemy enemy, Player player)
    {
        _enemy = enemy;
        _player = player;
        _areaObjectChecker = new AreaObjectChecker();

        InitStates();
    }

    private void InitStates()
    {
        IdleStateInitialize();
        ChaseStateInitialize();
        AttackStateInitialize();
    }

    public override void Enter<EnterState>()
    {
        _activeState?.Exit();
        EnemyStateBase state = _states[typeof(EnterState)];
        state.Enter();
        _activeState = state;
    }

    public void Update()
    {
        if(_activeState is IStateUpdateable state)
        {
            state.Update();
        }
    }

    private void ChaseStateInitialize()
    {
        EnemyChaseState state = new EnemyChaseState(_enemy, _player, _areaObjectChecker);

        state.OnPlayerCatchUp += Enter<EnemyAttackState>;
        state.OnPlayerCatchDown += Enter<EnemyIdleState>;

        _states.Add(typeof(EnemyChaseState), state);
    }

    private void IdleStateInitialize()
    {
        EnemyIdleState state = new EnemyIdleState(_enemy, _player, _areaObjectChecker);

        state.OnPlayerSee += Enter<EnemyChaseState>;

        _states.Add(typeof(EnemyIdleState), state);
    }

    private void AttackStateInitialize()
    {
        EnemyAttackState state = new EnemyAttackState(_enemy, _player, _areaObjectChecker);

        state.OnPlayerOutRange += Enter<EnemyIdleState>;

        _states.Add(typeof(EnemyAttackState), state);
    }
}
