using UnityEngine;
using Zenject;

namespace Assets.Scripts.Inits
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private Transform[] patrollingPoints;
        public override void InstallBindings()
        {
            Container.Bind<Transform[]>().FromInstance(patrollingPoints).NonLazy();
        }
    }
}