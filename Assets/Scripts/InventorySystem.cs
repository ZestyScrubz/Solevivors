using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
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

        // --- UI & Hotbar --- //
    public GameObject hotbar;                  // Used for slot highlighting (e.g. Slot1, Slot2...)

    public Sprite defaultSlotSprite;
    public Sprite selectedSlotSprite;

    public List<GameObject> quickSlots = new List<GameObject>();
    public List<string> quickSlotItemList = new List<string>();

    private int currentSelectedIndex = -1;
 
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
        HandleSlotInput();
        HandleCursorToggle();
    }

    void HandleCursorToggle()
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

    void HandleSlotInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectQuickSlot(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) SelectQuickSlot(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) SelectQuickSlot(3);
        else if (Input.GetKeyDown(KeyCode.Alpha4)) SelectQuickSlot(4);
        else if (Input.GetKeyDown(KeyCode.Alpha5)) SelectQuickSlot(5);
    }

    void SelectQuickSlot(int number)
    {
        int index = number - 1;

        // Deselect previously selected slot
        if (currentSelectedIndex != -1)
        {
            Transform prevSlot = hotbar.transform.Find("Slot" + (currentSelectedIndex + 1));
            if (prevSlot != null)
            {
                Image prevImage = prevSlot.GetComponent<Image>();
                if (prevImage != null)
                    prevImage.sprite = defaultSlotSprite;
            }
        }

        // Select new slot
        Transform currentSlot = hotbar.transform.Find("Slot" + number);
        if (currentSlot != null)
        {
            Image currentImage = currentSlot.GetComponent<Image>();
            if (currentImage != null)
                currentImage.sprite = selectedSlotSprite;
        }

        currentSelectedIndex = index;
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