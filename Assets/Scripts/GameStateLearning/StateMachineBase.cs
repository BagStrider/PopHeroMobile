using System;
using System.Collections.Generic;

public abstract class StateMachineBase<TState> where TState : IState
{
    protected Dictionary<Type, TState> _states;
    protected TState _activeState;

    public StateMachineBase()
    {
        _states = new Dictionary<Type, TState>();
    }

    public abstract void Enter<EnterState>() where EnterState : TState;
}
