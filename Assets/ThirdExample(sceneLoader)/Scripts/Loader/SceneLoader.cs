using System;

public class SceneLoader : ISimpleSceneLoader, ILevelLoader
{
    private ZenjectSceneLoaderWrapper _zenjectSceneLoader;

    public SceneLoader(ZenjectSceneLoaderWrapper zenjectSceneLoader)
    {
        _zenjectSceneLoader = zenjectSceneLoader;   
    }

    public void Load(SceneID sceneID)
    {
        if (sceneID == SceneID.GameplayLevel)
            throw new ArgumentException($"{SceneID.GameplayLevel} cannot be started without configuration");

        _zenjectSceneLoader.Load(null, (int)sceneID);
    }

    public void Load(LevelLoadingData loadingData)
    {
        _zenjectSceneLoader.Load(container =>
        {
            container.BindInstance(loadingData);
        }, (int)SceneID.GameplayLevel);
    }
}
