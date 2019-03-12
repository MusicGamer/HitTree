using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public static TreeController Instance;
    public GameObject log;
    private Queue<GameObject> logList = new Queue<GameObject>();
    public Transform[] logPoints;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < logPoints.Length; i++)
        {
            logList.Enqueue(Instantiate(log, logPoints[i]));
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void HitTree()
    {
        Destroy(logList.Dequeue());
        for (int i = 0; i < logPoints.Length - 1; i++)
        {
            
        }
        logList.Enqueue(Instantiate(log, logPoints[4]));
    }

    private void CreateLog()
    {

    }
}
