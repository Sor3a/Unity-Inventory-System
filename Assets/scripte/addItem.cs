using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class addItem : MonoBehaviour
{

    [SerializeField] Item item1,item2,item3;
    [SerializeField] createSlots slots;
    int slotsNumber;
    [SerializeField] IteamHolder iteamholder;
    int slotsActive;

    private void Start()
    {
        slotsNumber = slots.slotsNumber;
        slotsActive = 0;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            CkeckInventorySlots(this.item1);
        if (Input.GetKeyDown(KeyCode.J))
            CkeckInventorySlots(this.item2);
        if (Input.GetKeyDown(KeyCode.K))
            CkeckInventorySlots(this.item3);

    }
    void CkeckInventorySlots(Item item)
    {
        for (int i = 0; i < slotsNumber; i++)
        {
            if (slots.row1[i].interactable == false)
            {
                checkIfItemExistInInventory(item,i, slots.row1);
                break;
            }
        }
    }
    void checkIfItemExistInInventory(Item item, int i, List<Button> row)
    {
        if (iteamholder.itemsInInventory[item.itemID] == 0) //
        {
            row[i].interactable = true;
            row[i].onClick.AddListener(() => item.checkNumber());
            row[i].gameObject.GetComponent<Image>().sprite = item.icon;
            GameObject stuff = Instantiate(item.gameObject, row[i].gameObject.transform);
            iteamholder.itemsInInventory[item.itemID]++;
            iteamholder.itemsInInventoryI[item.itemID] = stuff;
            stuff.GetComponent<Item>().itemAdd(row[i].gameObject.transform.parent.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>(), iteamholder.itemsInInventory[item.itemID]);
            slotsActive++;
        } 
        else
        {
            iteamholder.itemsInInventory[item.itemID]++;
            iteamholder.itemsInInventoryI[item.itemID].GetComponent<Item>().itemAdd(iteamholder.itemsInInventoryI[item.itemID].transform.parent.gameObject.transform.parent.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>(), iteamholder.itemsInInventory[item.itemID]);
        }
    }

    public void ItemFinished(int itemUsedIndex, List<Button> row)
    {
        for (int i = itemUsedIndex; i < slotsActive - 1; i++)
        {
            row[i].onClick.RemoveAllListeners();
            if (row[i].transform.childCount != 0)
                Destroy(row[i].transform.GetChild(0).gameObject);
            Item item = row[i+1].transform.GetChild(0).gameObject.GetComponent<Item>();
            row[i + 1].transform.GetChild(0).SetParent(row[i].transform);
            row[i].onClick.AddListener(() => item.checkNumber());
            row[i].gameObject.GetComponent<Image>().sprite = item.icon;
            row[i].transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text = row[i+1].transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        }
        desactiveButton(row[slotsActive - 1]);
        slotsActive--;
    }

    void desactiveButton(Button b)
    {
        b.gameObject.GetComponent<Image>().sprite = null;
        b.interactable = false;
        b.onClick.RemoveAllListeners();
        b.transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";

    }
}
