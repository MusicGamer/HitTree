using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{

    SpriteRenderer spRend;
    Rigidbody2D rb;
    private float speed = 1000f; 

    // Start is called before the first frame update
    void Start()
    {
        spRend = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeOut()
    {
        for (float f = 1; f >= -0.5f; f -= 0.5f)
        {
            Color c = spRend.material.color;
            c.a = f;
            spRend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    }

    public void StartFading(Vector2 side)
    {
        rb.AddForce(side * speed);
        StartCoroutine("FadeOut");
    }
}
