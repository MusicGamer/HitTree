using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform[] pos = new Transform[2];

    private Touch touch;
    private float halfSreenSize;

    private void Awake()
    {
        halfSreenSize = Screen.width / 2;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount != 0)
        //{
        //    touch = Input.GetTouch(0);
        //    if (touch.phase == TouchPhase.Began && touch.position.x < halfSreenSize)
        //    {
        //        Debug.Log("left");
        //        transform.Translate(pos[0].position);
        //    }
        //    else if (touch.phase == TouchPhase.Began && touch.position.x > halfSreenSize)
        //    {
        //        Debug.Log("right");
        //        transform.Translate(pos[1].position);
        //    }
        //}

        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x < halfSreenSize)
            {
                transform.position = pos[0].position;
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (Input.mousePosition.x > halfSreenSize)
            {
                transform.position = pos[1].position;
                transform.rotation = new Quaternion(0, -180, 0, 0);
            }
        }
    }
}
