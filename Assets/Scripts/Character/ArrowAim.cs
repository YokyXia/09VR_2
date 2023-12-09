using UnityEngine;

public class ArrowAim : MonoBehaviour
{
    public Transform target; // �����洢Ŀ�������Transform

    void Update()
    {
        if (target != null &&  GlobalData.Instance.pos_flag)
        {
            // ���㳯��Ŀ��ķ�������
            Vector3 direction = target.position - transform.position;

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