using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{
    public GameObject Enemy;
    Transform playerTr; // ƒvƒŒƒCƒ„[‚ÌTransform

    int num = 0;
    int x;
    int z;
    [SerializeField] int LeftRangex = -6;
    [SerializeField] int RightRangex = 6;
    [SerializeField] int LeftRangez = -6;
    [SerializeField] int RightRangez = 6;
    [SerializeField] int maxEnemies = 10; // “G‚ÌÅ‘å”
    private int currentEnemyCount = 0; // Œ»İ‚Ì“G‚Ì”
    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 worldPos = myTransform.position;
        if (Vector3.Distance(transform.position, playerTr.position) < 3f)
            return;
        // “G‚ÌÅ‘å”‚É’B‚µ‚Ä‚¢‚éê‡A“G‚ğ¶¬‚µ‚È‚¢
        if (currentEnemyCount >= maxEnemies)
            return;
        x = Random.Range(LeftRangex, RightRangex);
        z = Random.Range(LeftRangez, RightRangez);
            num++;
        if (num % 300 == 0)
        {
            Instantiate(Enemy, new Vector3(worldPos.x + x, 1, worldPos.z + z), Quaternion.identity);
            currentEnemyCount++; // “G‚ğ¶¬‚·‚é‚½‚Ñ‚ÉƒJƒEƒ“ƒg‚ğ‘‚â‚·
        }
    }
    public void DecrementEnemyCount()
    {
        currentEnemyCount--;
    }
}
