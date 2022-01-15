using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IteamHolder : MonoBehaviour
{

   public List<int> itemsInInventory;
    public List<GameObject> itemsInInventoryI;


    public int number(int i)
    {
        return itemsInInventory[i];
    }
}
