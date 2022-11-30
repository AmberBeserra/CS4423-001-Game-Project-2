using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public ShopItem[] shopItems;
    public ShopFoundation[] texts;

     void Start()
    {
        LoadItems();
    }
    public void  LoadItems()
    {
        for (int i = 0; i < shopItems.Length; ++i)
        {
            texts[i].itemTxt.text = shopItems[i].item;
            texts[i].descriptionTxt.text = shopItems[i].description;
            texts[i].priceTxt.text = shopItems[i].price.ToString();
            texts[i].image = shopItems[i].image;
        }
    }
    }

