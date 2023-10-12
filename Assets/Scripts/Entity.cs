using System;
using UnityEngine;

public class Entity: MonoBehaviour
{
    public event Action OnDied;

    protected void Dies()
    {
        Debug.Log("Dead");

        OnDied?.Invoke();

        gameObject.SetActive(false);
    }
}
