using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnDestroy()
    {
        // �G���j�󂳂ꂽ�Ƃ��ɃJ�E���g�����炷
        EnemySpown spawner = FindObjectOfType<EnemySpown>();
        if (spawner != null)
        {
            spawner.DecrementEnemyCount();
        }
    }
}
