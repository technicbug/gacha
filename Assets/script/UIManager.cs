using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI capitalText;
    public TextMeshProUGUI inventoryText;
    public int inventory_item = 0;


    [System.Serializable]
    public class UIPanel
    {
        public string name;
        public GameObject panelObject;
        [HideInInspector] public CanvasGroup canvasGroup;
    }
    public List<GameObject> inventory; // 인스펙터에 자식들 연결

    public List<UIPanel> panels = new List<UIPanel>();

    private void Awake()
    {
        // 싱글톤 설정
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // 각 패널의 CanvasGroup 설정
        foreach (var panel in panels)
        {
            panel.canvasGroup = panel.panelObject.GetComponent<CanvasGroup>();
            if (panel.canvasGroup == null)
            {
                panel.canvasGroup = panel.panelObject.AddComponent<CanvasGroup>();
            }
        }
    }
    public void Start()
    {
        StartCoroutine(UpdateTimeText());
        SetItemActive(0);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { inventory_item = 0; SetItemActive(inventory_item); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { inventory_item = 1; SetItemActive(inventory_item); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { inventory_item = 2; SetItemActive(inventory_item); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { inventory_item = 3; SetItemActive(inventory_item); }
    }


    IEnumerator UpdateTimeText()
    {
        while (true)
        {
            timeText.text = gameManager.Instance.gameTime.get_time();
            Debug.Log(gameManager.Instance.gameTime.is_daytime);
            if (!gameManager.Instance.gameTime.is_daytime)
            {
                SetPanelAlpha("Idelpanel", 0.7f);
                // Debug.Log("앞라 수정 하자");
            }
            else
            {
                SetPanelAlpha("Idelpanel", 0.1f);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void ShowPanel(string panelName)
    {
        var panel = panels.Find(p => p.name == panelName);
        if (panel != null)
        {
            panel.canvasGroup.alpha = 1f;
            panel.canvasGroup.interactable = true;
            panel.canvasGroup.blocksRaycasts = true;
        }
    }

    public void HidePanel(string panelName)
    {
        var panel = panels.Find(p => p.name == panelName);
        if (panel != null)
        {
            panel.canvasGroup.alpha = 0f;
            panel.canvasGroup.interactable = false;
            panel.canvasGroup.blocksRaycasts = false;
        }
    }

    public void TogglePanel(string panelName)
    {
        var panel = panels.Find(p => p.name == panelName);
        if (panel != null)
        {
            bool isActive = panel.canvasGroup.alpha > 0f;
            if (isActive) HidePanel(panelName);
            else ShowPanel(panelName);
        }
    }

    public void SetPanelAlpha(string panelName, float alpha)
    {
        Debug.Log("배경 알파값을 수정합니다");
        var panel = panels.Find(p => p.name == panelName);
        if (panel != null)
        {
            // 패널의 바로 아래에 있는 Image 컴포넌트 찾기
            Image backgroundImage = panel.panelObject.GetComponent<Image>();
            if (backgroundImage != null)
            {
                Color color = backgroundImage.color;
                color.a = Mathf.Clamp01(alpha);
                backgroundImage.color = color;
            }
            else
            {
                Debug.LogWarning($"'{panelName}' 패널에 Image 컴포넌트가 없습니다.");
            }
        }
    }
    
    private string[] item = { "물뿌리게", "씨앗", "비료", "약" };

    public void SetItemActive(int index)
    {
        
        if (index >= 0 && index < inventory.Count)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (i == index)
                {
                    inventory[i].SetActive(true);
                    inventoryText.text = item[i];
                    Debug.Log($"{i}번째 아이템을 확성화 하였습니다");
                }
                else
                {
                    inventory[i].SetActive(false);
                }
            }


        }
        else
        {
            Debug.LogWarning("잘못된 인덱스");
        }
    }


}