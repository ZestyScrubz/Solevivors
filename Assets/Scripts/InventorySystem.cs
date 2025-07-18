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


    public void AddToInventory(string ItemName)
    {
        if (CheckIfFull()) 
        {
            Debug.Log("Inventory is full");
        }
        else
        {
            whatSlotToEquip = FindNextEmptySlot();
        }
    }

    public bool CheckIfFull()
    {
        
    }
 
    public GameObject FindNextEmptySlot()
    {

    }
}