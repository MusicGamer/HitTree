using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    public Slider timeBar;
    public Text scoreText;
    public TextMeshProUGUI finalText;
    public float maxTime = 100f;
    private int score = 0;
    private float time;
    private float regresSpeed = 1f;
    private float incriseTime = 2f;
    private bool startGame;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        startGame = false;
        scoreText.text = score.ToString();
        time = maxTime;
        timeBar.value = time / maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startGame = true;
            }
        }
        else
        {
            time -= regresSpeed * Time.deltaTime;
            timeBar.value = time / maxTime;
        }
    }

    public void UpScore(int value)
    {
        time = Mathf.Min(time + incriseTime, maxTime);
        score += value;
        regresSpeed = score;
        scoreText.text = score.ToString();
    }

    public void EndScreen()
    {
        finalText.text = scoreText.text;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
