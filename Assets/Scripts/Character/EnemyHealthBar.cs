using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform target; // 用来存储目标坐标的Transform

    void Update()
    {
        if (target != null)
        {
            // 计算朝向目标的方向向量
            Vector3 direction = target.position - transform.position;

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