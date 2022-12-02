using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GoldObj", menuName = "GoldObj", order = 1)]
public class GoldItem : ScriptableObject
{
    // Start is called before the first frame update
    public string goldAmount;
    
}
