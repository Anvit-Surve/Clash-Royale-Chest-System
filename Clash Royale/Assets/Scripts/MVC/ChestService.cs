using System;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : MonoSingletonGeneric<ChestService>
{
    public GameObject chestSlotGroup;
    [SerializeField] int noOfChestSlots;
    private ChestController[] chestSlots;
    [SerializeField] ChestScriptableObjectList chestSOL;
    [SerializeField] List<ChestView> unlockingQueue;
    [SerializeField] int allowedChestToUnlock = 3;
    [SerializeField] Sprite[] chestSprites;
    [SerializeField] ChestView chestPrefab;
    private ChestView popUpchest;
    private ChestModel chestModel;
    private ChestController chestController;
    private int chestSlotAlreadyOccupied = 0;

    private void Start()
    {
        chestSlots = new ChestController[noOfChestSlots];
        for (int i = 0; i< noOfChestSlots; i++)
        {
            chestSlots[i] = CreateEmptyChestSlot();
        }
    }

    private ChestController CreateEmptyChestSlot()
    {
        return CreateNewChestController(chestSOL.chestScriptableObjects[chestSOL.chestScriptableObjects.Length - 1], chestPrefab, chestSprites[chestSprites.Length - 1]);
    }
    private ChestController CreateNewChestController(ChestScriptableObject chestScriptableObject, ChestView chestPrefab, Sprite chestSprite)
    {
        chestModel = new ChestModel(chestScriptableObject);
        chestController = new ChestController(chestModel, chestPrefab, chestSprite);
        return chestController;
    }
    public void StartUnlockingFirstChest()
    {
        unlockingQueue.Add(popUpchest);
        popUpchest.chestController.isAddedToQueue = true;
    }
    public void CreateRandomChest()
    {
        for(int i = 0; i < 4; i++)
        {
            int randomChest = UnityEngine.Random.Range(0, chestSOL.chestScriptableObjects.Length - 1);
            AddChestToSlot(randomChest);
        } 
    }

    public void UnlockChestUsingGemsSelected()
    {
        popUpchest.chestController.UnlockChestUsingGems();
    }

    public void AddChestToUnlockingQueue()
    {
        if(unlockingQueue.Count == allowedChestToUnlock)
        {
            DisplayMessageOnPopUp("Unlocking Queue Limit Reached");
        }
        else
        {
            DisplayMessageOnPopUp("Chest added to Unlocking Queue");
            unlockingQueue.Add(popUpchest);
            popUpchest.chestController.isAddedToQueue = true;
        }
    }

    public void AddChestToSlot(int chestIndex)
    {
        for (int i = 0; i < chestSlots.Length; i++)
        {
            if (chestSlots[i].IsEmpty())
            {
                chestSlots[i].AddChestToController(chestSOL.chestScriptableObjects[chestIndex], chestSprites[chestIndex]);
                DisplayMessageOnPopUp("Chest Added to Slot:" + ++i);
                i = chestSlots.Length + 1;
            }
            else
            {
                chestSlotAlreadyOccupied++;
            }
        }
        if (chestSlotAlreadyOccupied == chestSlots.Length)
        {
            DisplayMessageOnPopUp("Chest not added. All Slots are occupied");
        }
    }
    public void DisplayMessageOnPopUp(string message)
    {
        PopUpManager.Instance.OnlyDisplay(message);
    }
    public void UnlockNextChest(ChestView unlockedChestView)
    {
        unlockingQueue.Remove(unlockedChestView);
    }
}
