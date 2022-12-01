using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "Menu", menuName = "New Shop Item", order =  1)]
public class ShopItem : ScriptableObject
{
    // Start is called before the first frame update
    public string item;
    public string description;
    public int price;
    public Sprite image;
}
