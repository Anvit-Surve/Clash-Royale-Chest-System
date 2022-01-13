using System;
using UnityEngine;

[Serializable]
public class ChestController
{
    [Header("Chest Properties")]
    public ChestType type;
    public int coins;
    public int gems;
    public int timeToUnlock;
    public string status;
    public int unlockGems;

    [HideInInspector]
    public bool isAddedToQueue;
    [HideInInspector]
    public bool isEmpty;
    [HideInInspector]
    public bool isLocked;
    [HideInInspector]
    private bool isChestCanBeUnlocked;
    private string message;
    private Sprite emptySprite;

    public ChestModel chestModel { get; }
    public ChestView chestView { get; }

    public ChestController(ChestModel chestModel, ChestView chestPrefab, Sprite chestSprite)
    {
        this.chestModel = chestModel;
        chestView = GameObject.Instantiate<ChestView>(chestPrefab);
        chestView.chestController = this;
        emptySprite = chestSprite;

    }

    public void MakeChestEmpty()
    {
        chestModel.SetType(ChestType.WoodenChest);
        chestModel.SetCoins(0);
        chestModel.SetGems(0);
        chestModel.SetTimeToUnlock(0);
        isEmpty = true;
        status = "Empty";
        isAddedToQueue = false;
        unlockGems = 0;
        chestView.DisplayChestData();
    }

    public void AddChestToController(ChestScriptableObject chestSO, Sprite chestSprite)
    {
        isLocked = true;
        isEmpty = false;
        type = chestSO.chestType;
        coins = UnityEngine.Random.Range(chestSO.minCoins, chestSO.maxCoins);
        gems = UnityEngine.Random.Range(chestSO.minGems, chestSO.maxGems);
        timeToUnlock = chestSO.UnlockTime;
        status = "Locked";
        chestView.currentSprite = chestSprite;
        chestView.DisplayChestData();
    }

    public void UnlockChestUsingGems()
    {

    }

    public void ChestUnlocked()
    {
        isLocked = false;
        status = "Unlocked";
        unlockGems = 0;
        chestView.DisplayChestData();
        ChestService.Instance.UnlockNextChest(chestView);
    }
    public bool IsEmpty()
    {
        return isEmpty;
    }
    public void ChestClicked()
    {
        if (isEmpty)
        {
            message = "Chest Slot is Empty";
            ChestService.Instance.DisplayMessageOnPopUp(message);
            return;
        }
    }
}
