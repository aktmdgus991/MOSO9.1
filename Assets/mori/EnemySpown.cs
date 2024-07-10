using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{
    public GameObject Enemy;
    Transform playerTr; // ÉvÉåÉCÉÑÅ[ÇÃTransform

    int num = 0;
    int x;
    int z;
    [SerializeField] int LeftRangex = -6;
    [SerializeField] int RightRangex = 6;
    [SerializeField] int LeftRangez = -6;
    [SerializeField] int RightRangez = 6;
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
        x = Random.Range(LeftRangex, RightRangex);
        z = Random.Range(LeftRangez, RightRangez);

        
        num++;
        if (num % 300 == 0)
        {
            Instantiate(Enemy, new Vector3(worldPos.x+x, 1, worldPos.z+z), Quaternion.identity);
        }
    }
}
