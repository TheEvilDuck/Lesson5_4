using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class EnemySpawner: IPause, ITickable
{
    private float _spawnCooldown;

    private List<Vector3> _spawnPoints;

    private EnemyFactory _enemyFactory;

    private PauseHandler _pauseHandler;
    private bool _isPaused = false;
    //хотел сначала сделать StopWork чиста на SetPause(false), но если мы паузу отожмем, то включится и спаунер (он же в списке IPause у PauseHandler), даже если нам
    //не надо включать спаунер. Как временное решение - дополнительный флаг. Если не придумаю что лучше, так и оставлю. 
    //при этом при паузе нам не надо таймер обнулять, так что это лучше подходит под паузу, поэтому два флага мб и хорошо
    private bool _working = false;
    private float _time = 0;

    public EnemySpawner(IEnumerable<Vector3> spawnPoints, float spawnCooldown)
    {
        _spawnPoints = spawnPoints.ToList();
        _spawnCooldown = spawnCooldown;
    }

    [Inject]
    private void Construct(EnemyFactory enemyFactory, PauseHandler pauseHandler)
    {
        _enemyFactory = enemyFactory;
        _pauseHandler = pauseHandler;

        _pauseHandler.Add(this);
    }

    public void SetPause(bool isPaused) => _isPaused = isPaused;

    public void StartWork()
    {
        StopWork();

        _working = true;
    }

    public void StopWork()
    {
        _time = 0;
        _working = false;
    }

    public void Tick()
    {
        if (_isPaused||!_working)
            return;

        if (_time>=_spawnCooldown)
        {
            _time = 0;
            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)]);
        }
        else
        {
            _time+=Time.deltaTime;
        }
        
    }

}
