using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnDestroy()
    {
        // 敵が破壊されたときにカウントを減らす
        EnemySpown spawner = FindObjectOfType<EnemySpown>();
        if (spawner != null)
        {
            spawner.DecrementEnemyCount();
        }
    }
}
