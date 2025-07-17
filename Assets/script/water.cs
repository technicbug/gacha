using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class water : MonoBehaviour
{

    public Animator animator;

    public Transform player;         // 따라갈 대상 (플레이어)
    public Vector3 offset = Vector3.zero;  // 위치 오프셋

    void Update()
    {
        // 플레이어가 오른쪽 보는 경우
        if (player.localScale.x > 0)
        {
            transform.localScale = new Vector3(-1.2f, 1.2f, 1);  // 원래 방향
        }
        else
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1); // 좌우 반전
        }

        if (player != null)
        {
            transform.position = player.position + offset;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("watering");
        }
    }
}
