using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    [HideInInspector]
    public ChestController chestController;

    //[Header("Text Settings")]
    //[SerializeField] private TextMeshProUGUI typeText;
    //[SerializeField] private TextMeshProUGUI coinsText;
    //[SerializeField] private TextMeshProUGUI gemsText;
    //[SerializeField] private TextMeshProUGUI statusText;
    //[SerializeField] private TextMeshProUGUI unlockGemsText;
    public Sprite currentSprite;

    void Start()
    {
        transform.SetParent(ChestService.Instance.chestSlotGroup.transform);
        chestController.MakeChestEmpty();
    }
    public void DisplayChestData()
    {
        //typeText.text = chestController.type.ToString();
        //gemsText.text = chestController.gems.ToString();
        //coinsText.text = chestController.coins.ToString();
        //statusText.text = chestController.status;
        //unlockGemsText.text = chestController.unlockGems.ToString();
        gameObject.GetComponent<Image>().sprite = currentSprite;
    }
    public void ChestButtonOnClick()
    {
        chestController.ChestClicked();
    }
}
