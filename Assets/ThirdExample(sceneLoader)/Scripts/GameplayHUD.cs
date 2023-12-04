using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplayHUD : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;

    private ISceneLoadMediator _sceneLoader;
    private Wallet _wallet;

    [Inject]
    private void Construct(ISceneLoadMediator sceneLoader, Wallet wallet)
    {
        _sceneLoader = sceneLoader;
        _wallet = wallet;
    }

    private void OnEnable()
        => _mainMenuButton.onClick.AddListener(OnMainMenuClick);

    private void OnDisable()
        => _mainMenuButton.onClick.RemoveListener(OnMainMenuClick);

    private void OnMainMenuClick()
        => _sceneLoader.GoToMainMenu();

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
            _wallet.AddCoins(10);

        if (Input.GetKeyUp(KeyCode.S))
            if (_wallet.IsEnough(10))
                _wallet.Spend(10);
    }
}
