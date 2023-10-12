using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<IContactInteractable>(out var contactObject))
        {
            contactObject.Interact();
        }
    }
}
