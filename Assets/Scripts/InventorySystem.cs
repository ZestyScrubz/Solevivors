using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class InventorySystem : MonoBehaviour
{
 
   public static InventorySystem Instance { get; set; }
 
    public GameObject inventoryScreenUI;

    public List<GameObject> slotList = new List<GameObject>(); // check if there is something inside the slot

    public List<string> itemList = new List<string>(); // the name of the item in the slot

    private GameObject itemToAdd;

    private GameObject whatSlotToEquip; // maybe change name

    public bool isShiftLock;

    public bool isFull; // check if inventory is full
 
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
 
 
    void Start()
    {
        isShiftLock = false;
        isFull = false;
        PopulateSlotList();
    }
 
    // going to all the slot to see which is free and add the item to it
    private void PopulateSlotList()
    {
        foreach (Transform child in inventoryScreenUI.transform) // search all the child class in each slot to see if it is taken
        {
            if (child.CompareTag("Slot"))
            {
                slotList.Add(child.gameObject);
            }
        }
    }
 
    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.LeftAlt) && !isShiftLock)
        {
 
		    Debug.Log("LeftAlt is pressed");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isShiftLock = true;
 
        }
        else if (Input.GetKeyDown(KeyCode.LeftAlt) && isShiftLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isShiftLock = false;
        }
    }


    public void AddToInventory(string itemName)
    {

        whatSlotToEquip = FindNextEmptySlot();

        itemToAdd = (GameObject)Instantiate(Resources.Load<GameObject>(itemName), whatSlotToEquip.transform.position, whatSlotToEquip.transform.rotation);
        itemToAdd.transform.SetParent(whatSlotToEquip.transform);

        itemList.Add(itemName);
    }

    public bool CheckIfFull()
    {
        int count = 0;

        foreach(GameObject slot in slotList) 
        {
            if (slot.transform.childCount > 0)
            {
                count += 1;
            }
        }
        
        if (count == 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
 
    public GameObject FindNextEmptySlot()
    {
        foreach (GameObject slot in slotList)
        {
            if (slot.transform.childCount == 0)
            {
                return slot;
            }

        }
        return new GameObject();
    }

}