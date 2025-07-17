// using JetBrains.Annotations;
// using Unity.VisualScripting;
// using UnityEngine;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movePower = 5f;   // 이동 속도
    public float verticalDeacc = 0.9f;  // 수직 이동 감속 계수 (0.9~0.99 추천)

    public float maxSpeed = 10f;  // 최대 이동 속도
    public Vector3 xy;

    private Rigidbody2D rb;
    private Animator anim;
    private bool is_vertical = false;
    private float playerScale = 0.35f;
    private float smoothMove = 0.1f; // 부드러운 가속을 위한 변수

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        anim = GetComponent<Animator>();   
    }

    void Update()
    {
        Move();
        xy = new Vector3(transform.position.x, transform.position.y, 0);
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 moveVelocity = Vector2.zero;
        anim.SetBool("isRun", false);

        if (horizontalInput != 0)
        {
            moveVelocity.x = horizontalInput * movePower;
            is_vertical = false;

            transform.localScale = new Vector3(Mathf.Sign(horizontalInput) * playerScale, playerScale, 1);
            if (!anim.GetBool("isJump"))
            {
                anim.SetBool("isRun", true);
            }
        }

        if (verticalInput != 0)
        {
            moveVelocity.y = verticalInput * movePower;
            is_vertical = true;

            if (!anim.GetBool("isJump"))
            {
                anim.SetBool("isRun", true);
            }
        }

        // 현재 속도를 기반으로 부드럽게 가속 적용
        Vector2 targetVelocity = moveVelocity;
        if (is_vertical)
        {
            targetVelocity.y *= verticalDeacc;
        }

        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, smoothMove);

        // 최대 속도 제한
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Tree"){

        Debug.Log("방금 뭐야?!");
        }
    }
}
