using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    private LevelLoadingData _levelLoadingData;

    public override void InstallBindings()
    {
        
    }

    [Inject]
    private void Construct(LevelLoadingData levelLoadingData)
    {
        _levelLoadingData = levelLoadingData;
        Debug.Log(_levelLoadingData.Level);
    }
}
