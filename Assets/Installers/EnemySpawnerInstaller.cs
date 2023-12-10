using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    [SerializeField]float _spawnCooldown;
    [SerializeField]List<Transform>_spawnPoints;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle().WithArguments(_spawnPoints.Select((pointTransform)=> pointTransform.position),_spawnCooldown);
    }
}
