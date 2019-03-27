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

    // Start is called before the first frame update
    void Start()
    {
        maxTimeText.text = GameData.maxTime.ToString();
        increaseTimeText.text = GameData.increaseTime.ToString();
        coinsText.text = GameData.coins.ToString();
        priceMaxTimeText.text = GameData.priceMaxTime.ToString();
        priceIncreaseTimeText.text = GameData.priceIncreaseTime.ToString();
    }   

    public void UpMaxTime()
    {
        if (GameData.coins >= GameData.priceMaxTime)
        {
            GameData.coins -= GameData.priceMaxTime;
            GameData.priceMaxTime *= 2;
            GameData.maxTime += 10f;
            priceMaxTimeText.text = GameData.priceMaxTime.ToString();
            maxTimeText.text = GameData.maxTime.ToString();
            coinsText.text = GameData.coins.ToString();
        }    
    }

    public void UpIncreaseTime()
    {
        if (GameData.coins >= GameData.priceIncreaseTime)
        {
            GameData.coins -= GameData.priceIncreaseTime;
            GameData.priceIncreaseTime *= 2;
            GameData.increaseTime += 3f;
            priceIncreaseTimeText.text = GameData.priceIncreaseTime.ToString();
            increaseTimeText.text = GameData.increaseTime.ToString();
            coinsText.text = GameData.coins.ToString();
        }      
    }
}
