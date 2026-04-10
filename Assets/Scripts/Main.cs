using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Main : MonoBehaviour {

    [Header("Linked UI")]
    public UISystem uiSystem;

    // UI stats
    public Image WaterStatusFill;
    public Image HealthStatusFill;
    public Image HappinessStatusFill;

    // Buttons
    public Button WaterButton;
    public Button FertilizerButton;
    public Button ShopButton;

    // Text Box
    public TextMeshProUGUI CoinAmountText;
    public TextMeshProUGUI FertilizerAmountText;

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
    void Start() {
        Debug.Log("Main started");
        water = 50f;
        health = 100f;
        happiness = 50f;
        coins = 0;
        fertilizerAmount = 1;
        fertilizerCooldown = 0f;
        isHealthDraining = false;
    }

    // Update is called once per frame
    void Update() {
        Debug.Log("Main updated");
        timer += Time.deltaTime;
        happinessDrainTimer += Time.deltaTime;
        
        if (fertilizerCooldown > 0f){
            fertilizerCooldown -= Time.deltaTime;
        }

        if (timer >= 2f) {
            timer = 0f;
            if (!isHealthDraining && happiness >= 75) {
                coins = Mathf.Clamp(coins + 1, 0, maxCoins);
            }
            if  (water == 0f) {
                isHealthDraining = true;
                health = Mathf.Clamp(health - 3f, 0, maxHealth);
            } else {
                health = Mathf.Clamp(health + 1f, 0, maxHealth);
            }
            Debug.Log("Water - 3");
            water = Mathf.Clamp(water - 3f, 0, maxWater);
        }
        if (happinessDrainTimer >= 1f){
            happinessDrainTimer = 0f;
            if (isHealthDraining) {
                happiness = Mathf.Clamp(happiness - 5f, 0, maxHappiness);
            }
        }

        // Apply changes to UI
        if (uiSystem != null){
            uiSystem.updateStatusFill(WaterStatusFill, water, maxWater);
            uiSystem.updateStatusFill(HealthStatusFill, health, maxHealth);
            uiSystem.updateStatusFill(HappinessStatusFill, happiness, maxHappiness);
            uiSystem.updateTextBox(CoinAmountText, coins);
            uiSystem.updateTextBox(FertilizerAmountText, fertilizerAmount);
        }
    }


    public void waterPlant() {
        water = maxWater;
        isHealthDraining = false;
    }

    public void fertilizePlant() {
        if (fertilizerCooldown <= 0f && fertilizerAmount >= 1){
            health = Mathf.Clamp(health + 10f, 0, maxHealth);
            fertilizerAmount = Mathf.Clamp(fertilizerAmount - 1, 0, maxFertilizer);
            fertilizerCooldown = 30f;
        }

    }

    public void buyFertilizer() {
        if (coins >= fertilizerCost){
            coins = Mathf.Clamp(coins - fertilizerCost, 0, maxCoins);
            fertilizerAmount = Mathf.Clamp(fertilizerAmount + 1, 0, maxFertilizer);
        }
    }
}
