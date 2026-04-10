using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateStatusFill(Image status, float current, float max){
        Debug.Log("updateStatusFill started");
        status.fillAmount = Mathf.Clamp01(current / max);
    }

    public void updateTextBox(TextMeshProUGUI textBox, int number){
        Debug.Log("updateTextBox started");
        textBox.text = "" + number;
    }

    // Button click event

}
