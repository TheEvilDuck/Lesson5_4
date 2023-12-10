using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private EnemySpawner _spawner;

    private PauseHandler _pauseHandler;

    [Inject]
    private void Construct(PauseHandler pauseHandler, EnemySpawner enemySpawner)
    {
        _pauseHandler = pauseHandler;
        _spawner = enemySpawner;

    }

    private void Start() 
    {
        _spawner.StartWork();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
            _pauseHandler.SetPause(true);

        if(Input.GetKeyUp (KeyCode.S))
            _pauseHandler.SetPause(false);
    }
}
