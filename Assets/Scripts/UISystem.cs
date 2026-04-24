using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    [Header("Linked Main")]
    public Main main;

    // UI stats
    public Image WaterStatusFill;
    public Image HealthStatusFill;
    public Image HappinessStatusFill;
    public Image HappinessSprite;

    // Text Box
    public TextMeshProUGUI CoinAmountText;
    public TextMeshProUGUI FertilizerAmountText;

    // Sprite
    public Sprite HappySprite;
    public Sprite SadSprite;


    public void updateStatusFill()
    {
        Debug.Log("updateStatusFill started");
        WaterStatusFill.fillAmount = Mathf.Clamp01(main.water / main.maxWater);
        HealthStatusFill.fillAmount = Mathf.Clamp01(main.health / main.maxHealth);
        HappinessStatusFill.fillAmount = Mathf.Clamp01(main.happiness / main.maxHappiness);
    }

    public void updateTextBox()
    {
        Debug.Log("updateTextBox started");
        CoinAmountText.text = "" + main.coins;
        FertilizerAmountText.text = "" + main.fertilizerAmount;
    }

    public void updateHappinessImage()
    {
        Debug.Log("updateHappinessImage started" + main.happiness);
        if (main.happiness < 50)
        {
            HappinessSprite.sprite = SadSprite;
        }
        else
        {
            HappinessSprite.sprite = HappySprite;
        }
    }

    // Button click event
    public void waterButtonClicked()
    {
        main.water = main.maxWater;
        main.isHealthDraining = false;
    }

    public void fertilizerButtonClicked()
    {
        if (main.fertilizerCooldown <= 0f && main.fertilizerAmount >= 1)
        {
            main.health = Mathf.Clamp(main.health + 10f, 0, main.maxHealth);
            main.fertilizerAmount = Mathf.Clamp(main.fertilizerAmount - 1, 0, main.maxFertilizer);
            main.fertilizerCooldown = 30f;
        }
    }

    public void shopButtonClicked()
    {
        if (main.coins >= main.fertilizerCost)
        {
            main.coins = Mathf.Clamp(main.coins - main.fertilizerCost, 0, main.maxCoins);
            main.fertilizerAmount = Mathf.Clamp(main.fertilizerAmount + 1, 0, main.maxFertilizer);
        }
    }
}
