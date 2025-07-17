using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;


//식물이 자라나고 돈이 계산되고 ...
//4/22 메모 다음에 인게임 타임 구현하자!
//4/24 메모 다음에 인게임 타임 함수 완료하고 제화 시스템을 구축하자
//5/13 메모 시간 마무리하고 제화 하자....
//5/15 메모 상점, 식물 함수 만들자
//5/20 메모 다음시간에는 UI 완성하자
//5/22 메모 UI매니저 사용법 익히고 UI 만들자
//6/10 식물이 자라나는 매커니즘 구현하자
//6/17 식물 코루틴 완성
//6/19 인벤토리 시스템 완성
public class gameManager : MonoBehaviour
{
    GameObject player;
    GameObject Cam;
    public static gameManager Instance;
    public GameTime gameTime = new GameTime();
    //1: 물뿌리게 2.씨앗 3.촉진제 4.약 5.쩌는 물뿌리게 6.쩌는 씨앗 7.쩌는 촉진제 8.쩌는 약
    public int inventory_item;



    void Awake()
    {
        // 싱글톤 생성
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Cam = GameObject.FindWithTag("MainCamera");
        gameTime.time_initialize();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime.updateTime(Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("키 눌림");
            gameTime.sleeping();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) { inventory_item = 1; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { inventory_item = 2; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { inventory_item = 3; }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { inventory_item = 4; }
        // if (Input.GetKeyDown(KeyCode.Alpha1)) { inventory_item = 1; }
        // if (Input.GetKeyDown(KeyCode.Alpha1)) { inventory_item = 1; }
        // if (Input.GetKeyDown(KeyCode.Alpha1)) { inventory_item = 1; }
        // if (Input.GetKeyDown(KeyCode.Alpha1)) { inventory_item = 1; }
        // if (Input.GetKeyDown(KeyCode.Alpha1)) { inventory_item = 1; }



    }




}
