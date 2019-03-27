using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public static TreeController Instance;
    public GameObject[] logs;
    private Queue<GameObject> logList = new Queue<GameObject>();

    private int maxLogs = 10;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxLogs; i++)
        {
            logList.Enqueue(Instantiate(logs[Random.Range(0, logs.Length)], new Vector2(transform.position.x, transform.position.y + i), Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void HitTree(bool side)
    {
        if (CheckBranch(side))
        {
            return;
        }
        Destroy(logList.Dequeue());
        GameController.Instance.UpScore(1);
        int counter = 0;
        foreach (var item in logList)
        {
            item.transform.position = new Vector2(transform.position.x, transform.position.y + counter);
            counter += 1;
        }
        logList.Enqueue(Instantiate(logs[Random.Range(0, logs.Length)], new Vector2(transform.position.x, transform.position.y + maxLogs - 1), Quaternion.identity));
        CheckBranch(side);
    }

    private bool CheckBranch(bool side)
    {
        if (side && logList.Peek().tag == "RightBranch")
        {           
            GameController.Instance.EndScreen();
            return true;
        }
        else if (!side && logList.Peek().tag == "LeftBranch")
        {
            GameController.Instance.EndScreen();
            return true;
        }
        return false;
    }
}
