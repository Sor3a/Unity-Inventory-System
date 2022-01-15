using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public int itemID;
    public Sprite icon;
    TextMeshProUGUI Number;
    IteamHolder iteamHolder;
    createSlots slots;



    public void checkNumber()
    {
        if (itemID == 0)
        {
            addHealth();
        }
        else if (itemID == 1)
        {
            addArmor();
        }
        else if (itemID == 2)
        {
            addgold();
        }
    }

    public void itemAdd(TextMeshProUGUI text, int number)
    {
        Number = text;
        //Debug.Log(iHoolder.itemsInInventory[0]);
        Number.text = number.ToString();
    }
    void addHealth()
    {
        Debug.Log("we add health");
        useItem();
    }
    void addArmor()
    {
        Debug.Log("we add armor");
        useItem();
    }
    void addgold()
    {
        Debug.Log("we add gold");
        useItem();
    }
    void useItem()
    {
        slots = FindObjectOfType<createSlots>();
        iteamHolder = FindObjectOfType<IteamHolder>();
        if (iteamHolder.number(itemID) > 1)
        {

            iteamHolder.itemsInInventory[itemID]--;
            itemAdd(slots.row1[rowNumber()].transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>(), iteamHolder.number(itemID));

        }
        else if (iteamHolder.itemsInInventory[itemID] == 1)
        {
            iteamHolder.itemsInInventory[itemID]--;
            slots.row1[rowNumber()].transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            FindObjectOfType<addItem>().ItemFinished(rowNumber(), slots.row1);

        }
    }

    int rowNumber()
    {

        int i = 0;
        for (i = 0; i < slots.slotsNumber; i++)
        {
            if (iteamHolder.itemsInInventoryI[itemID].transform.parent.gameObject == slots.row1[i].gameObject)
                break;
        }
        return i;
    }
}
