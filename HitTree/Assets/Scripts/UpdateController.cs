using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateController : MonoBehaviour
{

    public TextMeshProUGUI maxTimeText;
    public TextMeshProUGUI increaseTimeText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI priceMaxTimeText;
    public TextMeshProUGUI priceIncreaseTimeText;

    private int priceMaxTime = 10;
    private int priceIncreaseTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        maxTimeText.text = GameData.maxTime.ToString();
        increaseTimeText.text = GameData.increaseTime.ToString();
        coinsText.text = GameData.coins.ToString();
        priceMaxTimeText.text = priceMaxTime.ToString();
        priceIncreaseTimeText.text = priceIncreaseTime.ToString();
    }   

    public void UpMaxTime()
    {
        if (GameData.coins >= priceMaxTime)
        {
            GameData.coins -= priceMaxTime;
            priceMaxTime *= 2;
            GameData.maxTime += 10f;
            priceMaxTimeText.text = priceMaxTime.ToString();
            maxTimeText.text = GameData.maxTime.ToString();
            coinsText.text = GameData.coins.ToString();
        }    
    }

    public void UpIncreaseTime()
    {
        if (GameData.coins >= priceIncreaseTime)
        {
            GameData.coins -= priceIncreaseTime;
            priceIncreaseTime *= 2;
            GameData.increaseTime += 3f;
            priceIncreaseTimeText.text = priceIncreaseTime.ToString();
            increaseTimeText.text = GameData.increaseTime.ToString();
            coinsText.text = GameData.coins.ToString();
        }      
    }
}
