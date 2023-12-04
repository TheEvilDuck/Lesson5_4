using Zenject;

public class FirstExampleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<MovementHandler>().AsSingle();
    }
}
