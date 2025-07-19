using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    
    public static PlayerState Instance { get; set; }


    // ---- Player Health ---- //
    public float currentHealth;
    public float maxHealth;

    // ---- Player Hunger ---- //
    public float currentHunger;
    public float maxHunger;

    public float distanceTravelled = 0;
    Vector3 lastPosition;

    public GameObject playerBody;

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

    private void Start()
    {

        currentHealth = maxHealth;
        currentHunger = maxHunger;
    }


    public void Update()
    {

        distanceTravelled += Vector3.Distance(playerBody.transform.position, lastPosition);
        lastPosition = playerBody.transform.position;

        if (distanceTravelled >= 5) {
            distanceTravelled = 0;
            currentHunger -= 1;
        }


        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Pressed N");
            currentHealth -=10;
            
        }

    }



}
