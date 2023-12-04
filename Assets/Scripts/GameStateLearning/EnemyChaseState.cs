using System;
using UnityEngine;

public class EnemyChaseState : EnemyStateBase, IStateUpdateable
{
    public event Action OnPlayerCatchUp;

    public event Action OnPlayerCatchDown;

    private AreaObjectChecker _areaObjectChecker;

    public EnemyChaseState(Enemy enemy, Player player, AreaObjectChecker areaObjectChecker) : base(enemy, player)
    {
        _areaObjectChecker = areaObjectChecker;
    }

    public override void Enter()
    {
        Debug.Log("Chase State Active");
    }

    public override void Exit()
    {
        Debug.Log("Chase State Disable");
        _enemy.Movement.StopMoving();
    }

    public void Update()
    {
        Vector3 direction = _player.transform.position - _enemy.transform.position;

        _enemy.Movement.RotateTo(direction.normalized);
        _enemy.Movement.MoveTo(direction.normalized);

        CheckAreaForPlayer();
    }

    private void CheckAreaForPlayer()
    {
        if (_areaObjectChecker.CheckArea<Player>(_enemy.transform.position, 1f)) //magic numbers
        {
            OnPlayerCatchUp?.Invoke();
        }

        if (_areaObjectChecker.CheckArea<Player>(_enemy.transform.position, 6f) == false) //magic numbers
        {
            OnPlayerCatchDown?.Invoke();
        }
    }
}



