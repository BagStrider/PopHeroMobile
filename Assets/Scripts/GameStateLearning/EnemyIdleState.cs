using System;
using UnityEngine;

public class EnemyIdleState : EnemyStateBase, IStateUpdateable
{
    public event Action OnPlayerSee;

    private AreaObjectChecker _areaObjectChecker;

    public EnemyIdleState(Enemy enemy, Player player, AreaObjectChecker areaObjectChecker) : base(enemy, player)
    {
        _areaObjectChecker = areaObjectChecker;
    }

    public override void Enter()
    {
        Debug.Log("Idle State Active");
    }

    public override void Exit()
    {
        Debug.Log("Idle State Disable");
    }

    public void Update()
    {
        if(_areaObjectChecker.CheckArea<Player>(_enemy.transform.position, 6f))
        {
            OnPlayerSee?.Invoke();
        }
    }
}
