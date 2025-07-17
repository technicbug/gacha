using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeRender : MonoBehaviour

{


    public static bool is_touched = false;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            Debug.Log("충돌");
            is_touched = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            is_touched = false;
        }
    }

    // void SetAlpha(float alpha)
    // {
    //     Color c = spriteRenderer.color;
    //     c.a = Mathf.Clamp01(alpha);
    //     spriteRenderer.color = c;
    // }
}
