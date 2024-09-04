using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;          // 이동 속도
    public float jumpForce = 5f;      // 점프 힘
    public float attackRange = 2f;    // 공격 범위
    public float attackDamage = 10f;  // 공격 데미지
    public LayerMask enemyLayer;      // 적의 레이어 설정

    private bool isGrounded;          // 캐릭터가 땅에 있는지 여부를 확인
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
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
        {
            Attack();
        }
    }

    void Attack()
    {
        // 플레이어의 전방으로 레이캐스트를 쏴서 적을 탐지
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, attackRange, transform.forward, attackRange, enemyLayer);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Enemy"))
            {
                // 적에게 데미지를 줌
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(attackDamage);
                }
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
