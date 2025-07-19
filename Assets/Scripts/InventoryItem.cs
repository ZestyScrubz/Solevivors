// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;
 
// public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
// {
//     // --- Is this item trashable --- //
//     public bool isTrashable;
 
//     // --- Item Info UI --- //
//     private GameObject itemInfoUI;
 
//     private Text itemInfoUI_itemName;
//     private Text itemInfoUI_itemDescription;
//     private Text itemInfoUI_itemFunctionality;
 
//     public string thisName, thisDescription, thisFunctionality;
 
//     // --- Consumption --- //
//     private GameObject itemPendingConsumption;
//     public bool isConsumable;
 
//     public float healthEffect;
//     public float hungerEffect;
 
 
//     private void Start()
//     {
//         itemInfoUI = InventorySystem.Instance.ItemInfoUI;
//         itemInfoUI_itemName = itemInfoUI.transform.Find("itemName").GetComponent<Text>();
//         itemInfoUI_itemDescription = itemInfoUI.transform.Find("itemDescription").GetComponent<Text>();
//         itemInfoUI_itemFunctionality = itemInfoUI.transform.Find("itemFunctionality").GetComponent<Text>();
//     }
 
//     // Triggered when the mouse enters into the area of the item that has this script.
//     public void OnPointerEnter(PointerEventData eventData)
//     {
//         itemInfoUI.SetActive(true);
//         itemInfoUI_itemName.text = thisName;
//         itemInfoUI_itemDescription.text = thisDescription;
//         itemInfoUI_itemFunctionality.text = thisFunctionality;
//     }
 
//     // Triggered when the mouse exits the area of the item that has this script.
//     public void OnPointerExit(PointerEventData eventData)
//     {
//         itemInfoUI.SetActive(false);
//     }
 
//     // Triggered when the mouse is clicked over the item that has this script.
//     public void OnPointerDown(PointerEventData eventData)
//     {
//         //Right Mouse Button Click on
//         if (eventData.button == PointerEventData.InputButton.Right)
//         {
//             if (isConsumable)
//             {
//                 // Setting this specific gameobject to be the item we want to destroy later
//                 itemPendingConsumption = gameObject;
//                 consumingFunction(healthEffect, hungerEffect);
//             }
//         }
//     }
 
//     // Triggered when the mouse button is released over the item that has this script.
//     public void OnPointerUp(PointerEventData eventData)
//     {
//         if (eventData.button == PointerEventData.InputButton.Right)
//         {
//             if (isConsumable && itemPendingConsumption == gameObject)
//             {
//                 DestroyImmediate(gameObject);
//                 InventorySystem.Instance.ReCalculeList();
//                 CraftingSystem.Instance.RefreshNeededItems();
//             }
//         }
//     }
 
//     private void consumingFunction(float healthEffect, float hungerEffect)
//     {
//         itemInfoUI.SetActive(false);
 
//         healthEffectCalculation(healthEffect);
 
//         hungerEffectCalculation(hungerEffect);
 
 
//     }
 
 
//     private static void healthEffectCalculation(float healthEffect)
//     {
//         // --- Health --- //
 
//         float healthBeforeConsumption = PlayerState.Instance.currentHealth;
//         float maxHealth = PlayerState.Instance.maxHealth;
 
//         if (healthEffect != 0)
//         {
//             if ((healthBeforeConsumption + healthEffect) > maxHealth)
//             {
//                 PlayerState.Instance.setHealth(maxHealth);
//             }
//             else
//             {
//                 PlayerState.Instance.setHealth(healthBeforeConsumption + healthEffect);
//             }
//         }
//     }
 
 
//     private static void hungerEffectCalculation(float hungerEffect)
//     {
//         // --- hunger --- //
 
//         float hungerBeforeConsumption = PlayerState.Instance.currenthunger;
//         float maxhunger = PlayerState.Instance.maxhunger;
 
//         if (hungerEffect != 0)
//         {
//             if ((hungerBeforeConsumption + hungerEffect) > maxhunger)
//             {
//                 PlayerState.Instance.sethunger(maxhunger);
//             }
//             else
//             {
//                 PlayerState.Instance.sethunger(hungerBeforeConsumption + hungerEffect);
//             }
//         }
//     }
 
 
// }