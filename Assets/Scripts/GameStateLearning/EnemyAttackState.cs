using System;
using UnityEngine;

public class EnemyAttackState : EnemyStateBase, IStateUpdateable
{
    public event Action OnPlayerOutRange;

    private AreaObjectChecker _areaObjectChecker;

    public EnemyAttackState(Enemy enemy, Player player, AreaObjectChecker areaObjectChecker) : base(enemy, player)
    {
        _areaObjectChecker = areaObjectChecker;
    }

    public override void Enter()
    {
        Debug.Log("Attack State Active");
    }

    public override void Exit()
    {
        Debug.Log("Attack State Disable");
    }

    public void Update()
    {
        if (_areaObjectChecker.CheckArea<Player>(_enemy.transform.position, 4f) == false) //magic numbers
        {
            OnPlayerOutRange?.Invoke();
        }
    }
}
