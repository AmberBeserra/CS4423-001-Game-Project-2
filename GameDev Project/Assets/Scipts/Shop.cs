using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Shop : MonoBehaviour
{
    public ShopItem[] shopItems;
    public ShopFoundation[] texts;
    public GoldItem gold;
    public GoldFoundation golden;
<<<<<<< Updated upstream

     void Start()
=======
    public Button[] purchaseBtns;
    GameManager gameMan;
    public GameObject gObj;
   //public GameManager gameManager;



    private void Awake()
    {
        gameMan = gObj.GetComponent<GameManager>();
    }
    void Start()
>>>>>>> Stashed changes
    {
        Gold();
        LoadItems();
<<<<<<< Updated upstream
        Gold();
=======
        CheckPurchase();
        //Purchase();


>>>>>>> Stashed changes
    }
    public void LoadItems()
    {
        for (int i = 0; i < shopItems.Length; ++i)
        {
            texts[i].itemTxt.text = shopItems[i].item;
            texts[i].descriptionTxt.text = shopItems[i].description;
            texts[i].priceTxt.text = shopItems[i].price.ToString();
            texts[i].image = shopItems[i].image;
        }

    }
    public void Gold()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gold)
        {
            golden.goldAmountTxt.text = gameMan.CurrentScore.ToString();
        }
    }
    public void CheckPurchase()
    {
        int myInt;
        int.TryParse(golden.goldAmountTxt.text, out myInt);
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (myInt >= shopItems[i].price)
            {
                purchaseBtns[i].interactable = true;

            }
            else
            {
                purchaseBtns[i].interactable = false;
            }
        }
<<<<<<< Updated upstream
    }
=======

>>>>>>> Stashed changes
    }

    public void Purchase(int btnNum)
    {
        int tmpInt;
        int tmpInt2;
        int.TryParse(golden.goldAmountTxt.text, out tmpInt);
        tmpInt2 = tmpInt;


        if (tmpInt >= shopItems[btnNum].price)
        {
            tmpInt -= shopItems[btnNum].price;
            if (tmpInt < tmpInt2)
            {
                Debug.Log("Successfull Purchase");
                golden.goldAmountTxt.text = tmpInt.ToString();
            }
            else
            {
                Debug.Log("Purchase Failed and I dont know why");
            }
        }

        else
        {
            Debug.Log("You're broke, get some money");
        }
        CheckPurchase();

    }

    /*public void BuyWeakPotion()
    {
 
        if (CurrentScore < 60) //player can't spend more gold than the already have, provides an error message
        {
            Debug.Log("You don't have enough gold for this!");
        }
        else
        {
            CurrentScore -= 60; //otherwise, subtracts correct amount of gold from CurrentScore and update the gold counter on screen
            golden.goldAmountTxt.text = CurrentScore.ToString();
            //GoldToScore.text = CurrentScore.ToString();
            //PlayerPrefs.SetInt("gold_score_counter", CurrentScore);
            //add item to player inventory
        }
    } */



}