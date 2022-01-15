using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createSlots : MonoBehaviour
{

    public int slotsNumber;
    [SerializeField] GameObject slot;
    [SerializeField] RectTransform startPosition;
    public List<Button> row1;
    Transform panel;

     void Awake()
    {
        panel = transform.GetChild(0).GetComponent<Transform>();
    }

    void Start()
    {
        checkSlots();
    }

    void checkSlots() //check the number of slots and full the inentory depends on the number of slots you want to do
    {
        if (slotsNumber <= 6)
            setslots(row1, slotsNumber-1, 112, 0,0);

        else if (slotsNumber > 6 && slotsNumber <= 12)
        {
            setslots(row1, 5, 112, 0,0);
            setslots(row1, slotsNumber-1, 112, -100,6);
        }
        else if (slotsNumber > 12 && slotsNumber <= 18)
        {
            setslots(row1, 5, 112, 0,0);
            setslots(row1, 11, 112, -120,6);
            setslots(row1, slotsNumber-1, 112, -240,12);
        }
    }
    void setslots(List<Button> row, int Finalnumber,int x , int y,int startNumber) 
    {

        Vector3 startPos = new Vector3(startPosition.position.x , startPosition.position.y + y, startPosition.position.z); // set the position of the first slot
        createSlot(startPos, row);
        for (int i = startNumber; i < Finalnumber; i++)
        {
            RectTransform SlotTransform = row[i].gameObject.GetComponent<RectTransform>();
            Vector3 pos = new Vector3(SlotTransform.position.x + x, SlotTransform.position.y, SlotTransform.position.z); // set the position of the other slots by adding on their x value
            createSlot(pos, row);
        }
    }
    void createSlot(Vector3 position , List<Button> row)
    {
        GameObject slote = Instantiate(slot, slot.transform.position, Quaternion.identity); // create the slot gameobject
        slote.GetComponent<RectTransform>().position = position; // set the position we want
        Button sloteBut = slote.transform.GetChild(0).GetComponent<Button>();
        row.Add(sloteBut);  //add it to the list ( we gonna need it later)
        slote.transform.SetParent(panel);  //set the panel is the parent 
        sloteBut.interactable = false;
    }


}
