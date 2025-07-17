using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 target;
    public float baseSize = 5f;  // 기본 카메라 사이즈
    public float maxSize = 7f;   // 최대 카메라 사이즈
    public float speedFactor = 0.5f; // 속도에 따른 크기 증가량
    public float smoothSpeed = 2f; // 부드러운 변화 속도
    public float speed = 5f; // 이동 속도
    PlayerController playercontroller;
    public float y_offset = 0f;
    public float x_offset = 0f;
    public float[] init_offset = new float[2]{0f, 0f};
    private Vector3 velocity = Vector3.zero;
    public float CamMovePower;

    // private Rigidbody2D targetRb;
    // private Camera cam;


    void Start()
    {
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        target = playercontroller.xy;
        target = new Vector3(playercontroller.xy.x, playercontroller.xy.y, 1);
        init_offset[0] = x_offset;
        init_offset[1] = y_offset;
        

        
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector3(playercontroller.xy.x + x_offset, playercontroller.xy.y + y_offset, -10);
        // Debug.Log(playercontroller.xy);
        
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 0.3f);
 

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (horizontalInput != 0){
            x_offset = init_offset[0] + horizontalInput*CamMovePower;

        } else{
            x_offset = init_offset[0];
        }
        if (verticalInput != 0){
            y_offset = init_offset[1] + verticalInput*CamMovePower;

        } else{
            y_offset = init_offset[1];
        }

        // 속도에 따라 카메라 크기 설정
        // float targetSize = baseSize + targetRb.velocity.magnitude * speedFactor;
        // targetSize = Mathf.Clamp(targetSize, baseSize, maxSize);

        // 부드럽게 보간 (Lerp 사용)
        // cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, smoothSpeed * Time.deltaTime);



    }
}
