using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leafrenderer : MonoBehaviour
{
    public float distance_unit = 2f;
    private float distance;
    public Vector3 target;
    PlayerController playercontroller;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector3(playercontroller.xy.x, playercontroller.xy.y, 0);
        distance = Vector3.Distance(transform.position, target);
        if (treeRender.is_touched && distance <= distance_unit){
            SetAlpha(0.5f);
        }
        else{
            SetAlpha(1f);
        }
    }

    void SetAlpha(float alpha)
    {
        Color c = spriteRenderer.color;
        c.a = Mathf.Clamp01(alpha);
        spriteRenderer.color = c;
    }
}
