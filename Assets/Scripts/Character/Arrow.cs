using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boss;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.Instance.pos_flag)
        {
            if (GlobalData.Instance.done_flag == false)
            {
                GlobalData.Instance.done_flag = true;
                transform.position = new Vector3(GlobalData.Instance.x, GlobalData.Instance.y, GlobalData.Instance.z);
            }
            Vector3 direction = boss.transform.position - transform.position;
            float distance = direction.magnitude;
            if (distance > 0.1f)  // ���������0.1ʱ����������
            {
                Vector3 move = direction.normalized * 5f * Time.deltaTime;
                transform.Translate(move);
                if (direction != Vector3.zero)
                {
                    // ʹ��LookRotation�������㳯��Ŀ�����ת
                    Quaternion rotation = Quaternion.LookRotation(direction);

                    // Ӧ����ת��GameObject
                    transform.rotation = rotation;
                }
            }
        }
        
    }
}
