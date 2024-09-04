using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;  // 적의 초기 체력

    // 데미지를 받을 때 호출되는 함수
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    // 적이 사망할 때 호출되는 함수
    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Enemy destroyed!");
    }
}
