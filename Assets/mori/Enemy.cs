using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnDestroy()
    {
        // “G‚ª”j‰ó‚³‚ê‚½‚Æ‚«‚ÉƒJƒEƒ“ƒg‚ðŒ¸‚ç‚·
        EnemySpown spawner = FindObjectOfType<EnemySpown>();
        if (spawner != null)
        {
            spawner.DecrementEnemyCount();
        }
    }
}
