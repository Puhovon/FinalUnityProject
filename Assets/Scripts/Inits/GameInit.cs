using Zenject;

public class GameInit : MonoInstaller
{
    // [SerializeField] private Transform playerTransform;
    

    public override void InstallBindings()
    {
        // var buffable = playerTransform.GetComponent<IBufuble>();
        // Container.Bind<IBufuble>().FromInstance(buffable).NonLazy();
        // Container.Bind<BuffFactory>().AsSingle();
        Container.Bind<EnemyFactory>().AsSingle();
    }
}
