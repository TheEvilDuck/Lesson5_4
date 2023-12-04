using System;

public class Wallet
{
    public event Action<int> CoinsChanged;

    public Wallet(int coins)
    {
        if(coins < 0)
            throw new ArgumentOutOfRangeException(nameof(coins));

       Coins = coins;
    }

    public int Coins { get; private set; }

    public void AddCoins(int coins)
    {
        if (coins < 0)
            throw new ArgumentOutOfRangeException(nameof(coins));

        Coins += coins;
        CoinsChanged?.Invoke(Coins);
    }

    public bool IsEnough(int coins)
    {
        if (coins < 0)
            throw new ArgumentOutOfRangeException(nameof(coins));

        return Coins >= coins;
    }

    public void Spend(int coins)
    {
        if (coins < 0)
            throw new ArgumentOutOfRangeException(nameof(coins));

        Coins -= coins;
        CoinsChanged?.Invoke(Coins);
    }
}
