using Assets.Scripts.Global;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Health playerHelaHealth;
    public override void InstallBindings()
    {
        base.InstallBindings();
        Container.Bind<Health>().NonLazy();
    }

}
