using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed = 5f; // 이동 속도
    public float jumpForce = 5f; // 점프 힘
    private bool isGrounded; // 캐릭터가 땅에 있는지 여부를 확인

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontal * speed, rb.velocity.y);
        rb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 캐릭터가 땅에 있을 때만 점프할 수 있도록 설정
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // 캐릭터가 땅에서 떨어질 때
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
