using System;
using System.Collections;
using UnityEngine;

public class ContactBehaviour : MonoBehaviour
{
    public event Action<IContactInteractable> OnContact;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<IContactInteractable>(out var contactObject))
        {
            OnContact?.Invoke(contactObject);
        }
    }
}
