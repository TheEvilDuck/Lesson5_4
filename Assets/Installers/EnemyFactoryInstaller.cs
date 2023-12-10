using Zenject;

public class EnemyFactoryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<EnemyFactory>().AsSingle();
    }
}
