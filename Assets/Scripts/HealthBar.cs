using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class HealthBar : MonoBehaviour
{
    private Slider slider;

    public GameObject playerState;

    private float currentHealth, maxHealth;

    public void Awake()
    {

        slider = GetComponent<Slider>();

    }   

    public void Update()
    {

        currentHealth = playerState.GetComponent<PlayerState>().currentHealth;
        maxHealth = playerState.GetComponent<PlayerState>().maxHealth;

        float fillValue = currentHealth / maxHealth;
        slider.value = fillValue;
        
    } 
}
