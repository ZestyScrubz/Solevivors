using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class HungerBar : MonoBehaviour
{
    private Slider slider;

    public GameObject playerState;

    private float currentHunger, maxHunger;

    public void Awake()
    {

        slider = GetComponent<Slider>();

    }   

    public void Update()
    {

        currentHunger = playerState.GetComponent<PlayerState>().currentHunger;
        maxHunger = playerState.GetComponent<PlayerState>().maxHunger;

        float fillValue = currentHunger / maxHunger;
        slider.value = fillValue;


    } 
}
