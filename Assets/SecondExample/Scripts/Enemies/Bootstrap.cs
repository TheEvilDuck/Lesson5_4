using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    private PauseHandler _pauseHandler;

    [Inject]
    private void Construct(PauseHandler pauseHandler)
    {
        _pauseHandler = pauseHandler;
    }

    private void Awake()
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
