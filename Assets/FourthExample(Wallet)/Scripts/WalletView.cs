using TMPro;
using UnityEngine;
using Zenject;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _coins;

    private Wallet _wallet;

    [Inject]
    private void Construct(Wallet wallet) => _wallet = wallet;

    private void OnEnable()
    {
        _wallet.CoinsChanged += OnCoinsChanged;
        OnCoinsChanged(_wallet.Coins);
    }

    private void OnDisable()
    {
        _wallet.CoinsChanged -= OnCoinsChanged;
    }

    private void OnCoinsChanged(int coins) => _coins.text = coins.ToString();   
}
