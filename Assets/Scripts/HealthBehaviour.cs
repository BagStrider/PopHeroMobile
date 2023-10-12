using System;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    public event Action OnHealthOver;

    [SerializeField] private float _startedHP;

    private float _hp;

    private void Awake()
    {
        _hp = _startedHP;
    }

    public void TakeHealth(float value)
    {
        if(value <= 0) return;
        
        _hp -= value;

        if (_hp <= 0) OnHealthOver?.Invoke();
    }
}
