using Zenject;
using UnityEngine;
using Cinemachine;

public class LocationInstaller : MonoInstaller
{
    public Transform StartPoint;
    public GameObject PlayerPrefab;
    public FloatingJoystick Joystick;
    public CinemachineVirtualCamera PlayerCamera;

    public override void InstallBindings()
    {
        BindPlayerJoystick();
        BindPlayer();
    }

    private void BindPlayerJoystick()
    {
        Container
            .Bind<FloatingJoystick>()
            .FromInstance(Joystick)
            .AsSingle();
    }

    private void BindPlayer()
    {
        Player player = Container
            .InstantiatePrefabForComponent<Player>(PlayerPrefab, StartPoint.position, Quaternion.identity, null);

        Container
            .Bind<Player>()
            .FromInstance(player)
            .AsSingle();

        PlayerCamera.Follow = player.transform;
    }
}