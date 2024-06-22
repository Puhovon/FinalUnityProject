using UnityEngine;
using Zenject;

public class GameInit : MonoInstaller
{
    [SerializeField] private Transform playerTransform;

    public override void InstallBindings()
    {
        Container.Bind<Transform>().FromInstance(playerTransform).AsSingle().NonLazy();
    }
}
