using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public static TreeController Instance;
    public GameObject[] logs;
    private Queue<GameObject> logList = new Queue<GameObject>();

    private int maxLogs = 10;
    private bool mayLogBranch = false;
    private int currentLog;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    void Start()
    {
        logList.Enqueue(Instantiate(logs[0], new Vector2(transform.position.x, transform.position.y), Quaternion.identity));
        for (int i = 1; i < maxLogs; i++)
        {
            CreateLog(i);
        }
    }

    public void HitTree(bool side)
    {
        if (CheckBranch(side))
        {
            return;
        }
        if (side)
        {
            logList.Dequeue().GetComponent<Log>().StartFading(-transform.right);
        }
        else
        {
            logList.Dequeue().GetComponent<Log>().StartFading(transform.right);
        }       
        //Destroy(logList.Dequeue().GetComponent<Rigidbody2D>().AddForce(new Vector2(2, -4)));
        GameController.Instance.UpScore(1);
        int counter = 0;
        foreach (var item in logList)
        {
            item.transform.position = new Vector2(transform.position.x, transform.position.y + counter);
            counter += 1;
        }
        CreateLog(maxLogs - 1);
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

    private void CreateLog(int bias)
    {
        if (currentLog == 0)
        {
            currentLog = Random.Range(0, logs.Length);
            logList.Enqueue(Instantiate(logs[currentLog], new Vector2(transform.position.x, transform.position.y + bias), Quaternion.identity));
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                currentLog = 0;
            }
            logList.Enqueue(Instantiate(logs[currentLog], new Vector2(transform.position.x, transform.position.y + bias), Quaternion.identity));
        }
    }
}
