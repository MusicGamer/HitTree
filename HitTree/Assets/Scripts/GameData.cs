using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;
    public static float maxTime = 100f;
    public static float increaseTime = 2f;
    public static int coins = 0;
    public static int priceMaxTime = 10;
    public static int priceIncreaseTime = 10;
    public static int bestScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            GameDataSL gdsl = SaveLoadSystem.LoadData();
            maxTime = gdsl.maxTime;
            increaseTime = gdsl.increaseTime;
            coins = gdsl.coins;
            priceMaxTime = gdsl.priceMaxTime;
            priceIncreaseTime = gdsl.priceIncreaseTime;
            bestScore = gdsl.bestScore;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }      
        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationQuit()
    {
        SaveLoadSystem.SaveData();
    }
}

[System.Serializable]
public class GameDataSL
{
    public float maxTime;
    public float increaseTime;
    public int coins;
    public int priceMaxTime;
    public int priceIncreaseTime;
    public int bestScore;

    public GameDataSL(bool SorL)
    {
        maxTime = GameData.maxTime;
        increaseTime = GameData.increaseTime;
        coins = GameData.coins;
        priceMaxTime = GameData.priceMaxTime;
        priceIncreaseTime = GameData.priceIncreaseTime;
        bestScore = GameData.bestScore;
    }
}
    
