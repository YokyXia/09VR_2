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
            if (distance > 0.1f)  // 当距离大于0.1时，继续飞行
            {
                Vector3 move = direction.normalized * 5f * Time.deltaTime;
                transform.Translate(move);
                if (direction != Vector3.zero)
                {
                    // 使用LookRotation方法计算朝向目标的旋转
                    Quaternion rotation = Quaternion.LookRotation(direction);

                    // 应用旋转到GameObject
                    transform.rotation = rotation;
                }
            }
        }
        
    }
}
