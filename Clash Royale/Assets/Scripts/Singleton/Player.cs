using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoSingletonGeneric<Player>
{
    [Header("Player Scriptable Object")]
    [SerializeField] private PlayerScriptableObject playerSO;

    [Header("Text Settings")]
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI gemsText;

    [Header("Player Settings")]
    [SerializeField] private int coins;
    [SerializeField] private int gems;

    [HideInInspector]
    private bool sufficientGems;

    private void Start()
    {
        SetPlayerData(playerSO);
        ShowPlayerData();
    }

    private void SetPlayerData(PlayerScriptableObject playerSO)
    {
        coins = playerSO.coins;
        gems = playerSO.gems;
    }

    private void ShowPlayerData()
    {
        coinsText.text = coins.ToString();
        gemsText.text = gems.ToString();
    }

    public void AddToPlayer(int coinsToAdd, int gemsToAdd)
    {
        coins += coinsToAdd;
        gems += gemsToAdd;
    }

    public bool RemoveFromPlayer(int gemsTORemove)
    {
        sufficientGems = true;
        if(gems >= gemsTORemove)
        {
            gems -= gemsTORemove;
        }
        else
        {
            sufficientGems = false;
        }
        ShowPlayerData();
        return sufficientGems;
    }
}
