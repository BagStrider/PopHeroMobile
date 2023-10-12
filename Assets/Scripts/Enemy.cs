using UnityEngine;

public class Enemy : Entity , IContactInteractable
{
    [SerializeField] private HealthBehaviour _healthBeh;

    private void Awake()
    {
        _healthBeh.OnHealthOver += Dies;
    }

    public void Interact()
    {
        _healthBeh.TakeHealth(1f);
    }
}
