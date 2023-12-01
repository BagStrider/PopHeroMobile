using UnityEngine;

public class Player: MonoBehaviour
{
    public PlayerMovement Movement => _controller.Movement;
    public PlayerController Controller => _controller;

    [SerializeField] private ContactBehaviour _contactBeh;

    private PlayerController _controller;

    private PlayerContactBehaviour _playerContact;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>(); 

        _playerContact = new PlayerContactBehaviour(_contactBeh, this);
    }
}
