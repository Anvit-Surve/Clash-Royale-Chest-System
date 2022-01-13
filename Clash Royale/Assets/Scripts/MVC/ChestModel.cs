using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestModel
{
    private ChestType Type { get; set; }
    private int Coins { get; set; }
    private int Gems { get; set; }
    public int TimeToUnlock { get; set; }

    public ChestModel(ChestScriptableObject chestSO)
    {
        Type = chestSO.chestType;
        Coins = Random.Range(chestSO.minCoins, chestSO.maxCoins);
        Gems = Random.Range(chestSO.minGems, chestSO.maxGems);
        TimeToUnlock = chestSO.UnlockTime;
    }

    public void SetType(ChestType type)
    {
        Type = type;
    }
    public void SetCoins(int coins)
    {
        Coins = coins;
    }
    public void SetGems(int gems)
    {
        Gems = gems;
    }
    public void SetTimeToUnlock(int time)
    {
        TimeToUnlock = time;
    }
}
