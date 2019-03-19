using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateController : MonoBehaviour
{

    public TextMeshProUGUI maxTimeText;

    // Start is called before the first frame update
    void Start()
    {
        maxTimeText.text = GameData.maxTim.ToString();
    }

    public void UpMaxTime()
    {
        GameData.maxTim += 10f;
        maxTimeText.text = GameData.maxTim.ToString();
    }

    public void UpIncriseTime()
    {
        GameData.incriseTime += 3f;
    }
}
