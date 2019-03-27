using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    public TextMeshProUGUI bestScore;

    // Start is called before the first frame update
    void Start()
    {
        bestScore.text = GameData.bestScore.ToString();
    }
}
