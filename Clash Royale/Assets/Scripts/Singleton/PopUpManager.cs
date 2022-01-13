using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

    class PopUpManager : MonoSingletonGeneric<PopUpManager>
    {
        [SerializeField] private GameObject popUpScreen;
        [SerializeField] private TextMeshProUGUI message;
        [SerializeField] private Button firstButton;
        [SerializeField] private Button secondButton;
        [SerializeField] private TextMeshProUGUI firstButtonText;
        [SerializeField] private TextMeshProUGUI secondButtonText;
        private Coroutine popUpCoroutine;

        public void DisplayPopUp(bool chestAddedToQueue, string message, int gemsToUnlock)
        {
            popUpScreen.SetActive(true);
            if(popUpCoroutine != null)
            {
                StopCoroutine(popUpCoroutine);
            }
            else
            {
                firstButtonText.text = "Add Chest to Unlocking Queue";
            }
            secondButtonText.text = "Unlock using Gems: " + gemsToUnlock.ToString();
            this.message.text = message;
            if (chestAddedToQueue)
            {
                firstButton.transform.gameObject.SetActive(false);
            }
            else
            {
                firstButton.transform.gameObject.SetActive(true);
            }
            secondButton.transform.gameObject.SetActive(true);
        }

        public void OnFirstBtnClick()
        {
            popUpScreen.SetActive(false);
            ChestService.Instance.AddChestToUnlockingQueue();
        }
        public void OnUnlockChestBtnClicked()
        {
            popUpScreen.SetActive(false);
            ChestService.Instance.UnlockChestUsingGemsSelected();
        }
        public void OnlyDisplay(string message)
        {
            popUpScreen.SetActive(true);
            this.message.text = message;
            firstButton.transform.gameObject.SetActive(false);
            secondButton.transform.gameObject.SetActive(false);
            popUpCoroutine = StartCoroutine(DisablePopUp());
        }
        IEnumerator DisablePopUp()
        {
            yield return new WaitForSeconds(2f);
            popUpScreen.SetActive(false);
        }
    }
