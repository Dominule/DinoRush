using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;      // pro překlikávání mezi scénami
using TMPro;

public class ShopControl : MonoBehaviour
{
    int moneyAmount;
    int isItemSold;
    string itemName;
    string itemNameOfSelected;
    int itemPrice;

    public TextMeshProUGUI moneyAmountText;
    public TextMeshProUGUI itemPriceText;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI selectButtonText;

    public Button selectButton;
    public Button buyButton;
    
    // Start is called before the first frame update
    void Start()
    {
        itemName = itemNameText.text;
        itemPrice = int.Parse(itemPriceText.text);

        //  buyButton.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        moneyAmount = PlayerPrefs.GetInt("generalCoins", 0);
        moneyAmountText.text = moneyAmount.ToString();

        isItemSold = PlayerPrefs.GetInt(itemName, 0);

        if (isItemSold == 1 || itemName == "Brontosaurus")
        {
            if (itemName != "Brontosaurus")
                itemPriceText.text = "Sold!";
            buyButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
        }


        if (moneyAmount >= itemPrice && isItemSold == 0)
        {
            buyButton.gameObject.SetActive(true);
            buyButton.interactable = true;
        }           
        else if (moneyAmount <= itemPrice && isItemSold == 0)
        {
            buyButton.gameObject.SetActive(true);
            buyButton.interactable = false;                           // tady vždycky FALSE
        }

        itemNameOfSelected = PlayerPrefs.GetString("selectedDino");
        if (itemNameOfSelected != itemNameText.text)
        {
            selectButtonText.text = "Select";
        }
        else if (itemNameOfSelected == itemNameText.text)
        {
            selectButtonText.text = "Selected";
        }
    }

    public void BuyItem()
    {
        itemPrice = int.Parse(itemPriceText.text);

        Debug.Log(itemPriceText.text);

        moneyAmount -= itemPrice;                           // tady to taky změnit!!!
        PlayerPrefs.SetInt(itemName, 1);
        itemPriceText.text = "Sold!";
        buyButton.gameObject.SetActive(false);
        PlayerPrefs.SetInt("generalCoins", moneyAmount);
    }

    public void SelectItem()
    {
        // udělat, aby se text změnil na "selected"
        PlayerPrefs.SetString("selectedDino", itemName);
        Debug.Log(itemName + " selected");

    }


    public void LoadProfil()
    {
        PlayerPrefs.SetInt("generalCoins", moneyAmount);
        SceneManager.LoadScene("DinoProfil");     
    }

}
