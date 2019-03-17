using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public static TreeController Instance;
    public GameObject[] logs;
    private Queue<GameObject> logList = new Queue<GameObject>();
    public Transform[] logPoints;

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
        for (int i = 0; i < logPoints.Length; i++)
        {
            logList.Enqueue(Instantiate(logs[Random.Range(0, logs.Length)], logPoints[i]));
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
            item.transform.position = logPoints[counter].position;
            counter += 1;
        }
        logList.Enqueue(Instantiate(logs[Random.Range(0, logs.Length)], logPoints[4]));
        CheckBranch(side);
    }

    private bool CheckBranch(bool side)
    {
        if (side && logList.Peek().tag == "RightBranch")
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            GameController.Instance.EndScreen();
            return true;
        }
        else if (!side && logList.Peek().tag == "LeftBranch")
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            GameController.Instance.EndScreen();
            return true;
        }
        return false;
    }
}
