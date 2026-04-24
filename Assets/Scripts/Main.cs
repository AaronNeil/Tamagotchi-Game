using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Main : MonoBehaviour
{

    [Header("Linked UI")]
    public UISystem uiSystem;

    // Buttons
    public Button WaterButton;
    public Button FertilizerButton;
    public Button ShopButton;

    // Max values
    public float maxWater = 100f;
    public float maxHealth = 100f;
    public float maxHappiness = 100f;
    public int maxCoins = 999;
    public int maxFertilizer = 99;
    public int fertilizerCost = 5;

    // Current Values
    public float water;
    public float health;
    public float happiness;
    public int coins;
    public int fertilizerAmount;
    public bool isHealthDraining;

    // Timers
    public float timer;
    public float happinessDrainTimer;
    public float fertilizerCooldown;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Main started");
        water = 50f;
        health = 50f;
        happiness = 50f;
        coins = 0;
        fertilizerAmount = 1;
        fertilizerCooldown = 0f;
        isHealthDraining = false;
        WaterButton.onClick.AddListener(uiSystem.waterButtonClicked);
        FertilizerButton.onClick.AddListener(uiSystem.fertilizerButtonClicked);
        ShopButton.onClick.AddListener(uiSystem.shopButtonClicked);
        // Click shop

        Debug.Log("Main done");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Main updated");
        timer += Time.deltaTime;
        happinessDrainTimer += Time.deltaTime;

        if (fertilizerCooldown > 0f)
        {
            fertilizerCooldown -= Time.deltaTime;
        }

        if (timer >= 2f)
        {
            timer = 0f;
            if (!isHealthDraining && happiness >= 75)
            {
                coins = Mathf.Clamp(coins + 1, 0, maxCoins);
            }
            if (water == 0f)
            {
                isHealthDraining = true;
                health = Mathf.Clamp(health - 3f, 0, maxHealth);
            }
            else
            {
                health = Mathf.Clamp(health + 1f, 0, maxHealth);
            }
            Debug.Log("Water - 3");
            water = Mathf.Clamp(water - 3f, 0, maxWater);
        }

        // Happiness logic
        if (happinessDrainTimer >= 1f)
        {
            happinessDrainTimer = 0f;
            if (isHealthDraining)
            {
                happiness = Mathf.Clamp(happiness - 5f, 0, maxHappiness);
            }
            else
            {
                happiness = Mathf.Clamp(happiness + 3f, 0, maxHappiness);
            }
        }

        // Apply changes to UI
        if (uiSystem != null)
        {
            uiSystem.updateStatusFill();
            uiSystem.updateTextBox();
            uiSystem.updateHappinessImage();

        }
    }
}
