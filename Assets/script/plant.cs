using Unity.VisualScripting;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int growthStage = 1;           // 1: 새싹, 2: 중간, 3: 성숙
    public bool isWatered = false;
    public bool isSick = false;
    public bool isDead = false;
    public int random_watering_cycle = 1;

    public Animator animator;

    private int plantedDay;

    void Start()
    {
        animator = GetComponent<Animator>();
        plantedDay = gameManager.Instance.gameTime.get_day();
        UpdateGrowthStage();  // 시작 시 상태 업데이트
        StartCoroutine(RandomIllnessRoutine());
        
        
    }

    void Update()
    {
        if (isDead) return;

        UpdateGrowthStage();// 식물 자람 관리
    }

    void UpdateGrowthStage()//날짜에 따라 성장
    {
        int daysSincePlanted = gameManager.Instance.gameTime.get_day() - plantedDay;

        int newStage = daysSincePlanted + 1;

        if (newStage != growthStage)
        {
            newday(newStage);
            growthStage = newStage;
            animator.SetInteger("GrowthStage", growthStage);
            Debug.Log("Plant updated to stage: " + growthStage);
        }
    }

    public void WaterPlant() //물주기
    {
        if (isDead) return;

        isWatered = true;
        animator.SetTrigger("Watered");
        StartCoroutine(Wateringcycle());
    }

    public void UseFertilizer(float deathChance)//비료제
    {
        if (isDead) return;

        if (Random.value < deathChance)
        {
            Die("Over-fertilized");
            return;
        }

        plantedDay--;

    }

    public void GiveMedicine(float cureChance)
    {
        if (isDead || !isSick) return;

        if (Random.value < cureChance)
        {
            isSick = false;
            animator.SetTrigger("Cured");
        }
        else
        {
            animator.SetTrigger("FailedCure");
        }
    }

    void Die(string reason)
    {
        isDead = true;
        animator.SetTrigger("Dead");
        Debug.Log("Plant died: " + reason);
    }

    System.Collections.IEnumerator RandomIllnessRoutine()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(Random.Range(60f, 300f));
            if (!isSick && Random.value < 0.1f)
            {
                isSick = true;
                animator.SetTrigger("Sick");
                Debug.Log("Plant got sick!");
            }
        }
    }

    System.Collections.IEnumerator Wateringcycle() {
        while (!isDead && random_watering_cycle > 0)
        {
            yield return new WaitForSeconds(Random.Range(30f, 60f));
            isWatered = false;
            random_watering_cycle--;
        }
            
    }

    public void newday(int Plant_state)
    {
        if (isWatered == false)
        {
            if (Random.Range(0f, 100f) < 50f)
            {
                Die("dried up");
            }
        }
        if (isSick)
        {
            Die("sick");
        }
        if (Plant_state != 3)
        {
            isWatered = false;

        }
        //1 이녀석이 오늘 물을 몇번 줘야하나 정하고, 2 병에 걸릴지 안걸릴지 정하고, 근데 식물이 다 다랐으면 패스
    }
}
