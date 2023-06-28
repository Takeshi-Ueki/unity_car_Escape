using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // player �I�u�W�F�N�g�̎擾
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // �t���[�����Ƃɓ����ŗ���������
        transform.Translate(0, -0.02f, 0);

        // ��ʊO�ɏo����I�u�W�F�N�g��j��
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // �����蔻��
        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 0.95f;

        // ��ƃv���C���[�̏Փ˔���
        if (d < r1 + r2)
        {
            // �ēX�N���v�g�̃��\�b�h�Ăяo��
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            // ����폜
            Destroy(gameObject);
        }
    }
}
