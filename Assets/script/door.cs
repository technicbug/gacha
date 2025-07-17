using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    GameObject player;
    GameObject Cam;
    public Vector2 houseLoc;
    private bool is_in = false;
    private float distance;
    PlayerController playercontroller;
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {

        // playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        player = GameObject.FindWithTag("Player");
        Cam = GameObject.FindWithTag("MainCamera");


    }

    // Update is called once per frame
    void Update()
    {
        // target = new Vector3(playercontroller.xy.x, playercontroller.xy.y, 0);
        // distance = Vector3.Distance(transform.position, target);
        if (is_in)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                player.transform.position = new Vector2(houseLoc.x, houseLoc.y);
                Cam.transform.position = new Vector3(houseLoc.x, houseLoc.y, -10);
                Debug.Log("집으로 들어갑니다");
            }

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            is_in = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            is_in = false;

        }

    }
    

}