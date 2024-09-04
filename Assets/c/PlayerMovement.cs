using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // 이동 속도
    public float jumpForce = 5f; // 점프 힘
    public float attackRange = 2f;  // 공격 범위
    public LayerMask enemyLayer;    // 적의 레이어 설정

    private bool isGrounded; // 캐릭터가 땅에 있는지 여부를 확인
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal * speed, rb.velocity.y, 0); // 3D 벡터로 수정
        rb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // 3D 벡터로 수정
        }
    }

    void HandleAttack()
    {
        // J 키로 공격
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }

        // K 키로 공격
        if (Input.GetKeyDown(KeyCode.K))
        {
            Attack();
        }
    }

    void Attack()
    {
        // 플레이어 앞의 특정 범위 내에서 적을 탐지
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, attackRange, enemyLayer);

        foreach (RaycastHit hit in hits)
        {
            // 탐지된 적 파괴
            if (hit.collider != null)
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("Enemy destroyed!");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 캐릭터가 땅에 있을 때만 점프할 수 있도록 설정
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // 캐릭터가 땅에서 떨어질 때
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        // 공격 범위를 시각적으로 표시
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * attackRange); // 3D 벡터로 수정
    }
}
