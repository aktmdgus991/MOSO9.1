using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{
    public GameObject Enemy;
    Transform playerTr; // �v���C���[��Transform

    int num = 0;
    int x;
    int z;
    [SerializeField] int LeftRangex = -6;
    [SerializeField] int RightRangex = 6;
    [SerializeField] int LeftRangez = -6;
    [SerializeField] int RightRangez = 6;
    [SerializeField] int maxEnemies = 10; // �G�̍ő吔
    private int currentEnemyCount = 0; // ���݂̓G�̐�
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
        // �G�̍ő吔�ɒB���Ă���ꍇ�A�G�𐶐����Ȃ�
        if (currentEnemyCount >= maxEnemies)
            return;
        x = Random.Range(LeftRangex, RightRangex);
        z = Random.Range(LeftRangez, RightRangez);
            num++;
        if (num % 300 == 0)
        {
            Instantiate(Enemy, new Vector3(worldPos.x + x, 1, worldPos.z + z), Quaternion.identity);
            currentEnemyCount++; // �G�𐶐����邽�тɃJ�E���g�𑝂₷
        }
    }
    public void DecrementEnemyCount()
    {
        currentEnemyCount--;
    }
}
