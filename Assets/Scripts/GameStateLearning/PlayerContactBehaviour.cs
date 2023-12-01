public class PlayerContactBehaviour: System.IDisposable
{
    private ContactBehaviour _contactBeh;
    private Player _player;

    public PlayerContactBehaviour(ContactBehaviour contactBeh, Player player)
    {
        _contactBeh = contactBeh;
        _player = player;

        Initialize();
    }


    private void Initialize()
    {
        _contactBeh.OnContact += Interact;
    }
    
    private void Interact(IContactInteractable contactObj)
    {
        contactObj.Interact();

        if(contactObj is Enemy) Knockback();
    }

    private void Knockback()
    {
        _player.Controller.DisableMovementForSeconds(.5f);
        _player.Movement.AddForce(-_player.transform.up.normalized * 10f);
    }

    public void Dispose()
    {
        _contactBeh.OnContact -= Interact;
    }
}