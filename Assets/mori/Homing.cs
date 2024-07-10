using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    Transform playerTr; // �v���C���[��Transform
    [SerializeField] float speed = 2; // �G�̓����X�s�[�h

    private void Start()
    {
        // �v���C���[��Transform���擾�i�v���C���[�̃^�O��Player�ɐݒ�K�v�j
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {

        // �v���C���[�Ƃ̋�����0.1f�����ɂȂ����炻��ȏ���s���Ȃ�
        if (Vector3.Distance(transform.position, playerTr.position) < 1.5f)
            return;

        // �v���C���[�Ɍ����Đi��
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(playerTr.position.x, 1,playerTr.position.z),
            speed * Time.deltaTime);
    }
}
