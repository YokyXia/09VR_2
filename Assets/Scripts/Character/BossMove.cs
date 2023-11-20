using UnityEngine;

public class BossMove : MonoBehaviour
{
    public Transform[] waypoints;  // 存储三个运动点的Transform组件
    public float speed = 1f;  // 物体的运动速度

    private int currentWaypointIndex = 0;  // 当前运动点的索引
    private bool movingForward = true;  // 是否正向运动
    private bool boolflag = true;
    public GameObject boss;
    private float time = 0f;
    private int flag = 0;

    private void Update()
    {
        // 获取当前运动点
        Transform currentWaypoint = waypoints[currentWaypointIndex];

        // 计算物体朝向运动点的方向
        Vector3 direction = -(currentWaypoint.position - transform.position).normalized;

        // 计算物体朝向运动方向的旋转角度
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        // 将物体的x轴负方向设置为运动方向
        boss.transform.rotation = Quaternion.Euler(-targetRotation.eulerAngles.x, -targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);

        // 计算物体的下一步位置
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);

        // 移动物体到下一步位置
        transform.position = nextPosition;

        // 若物体已接近当前运动点，则切换到下一个运动点
        if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.01f)
        {          // 切换运动方向
          
            if (movingForward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = waypoints.Length - 2;
                    movingForward = false;
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1;
                    movingForward = true;
                }
            }
        }

        if(flag!=currentWaypointIndex)
        {
            speed = 0f;
            time += Time.deltaTime;
            if (time > 1)
            {
                flag = currentWaypointIndex;
                speed = 1f;
                time = 0f;
            }
        }
        //if (flag == currentWaypointIndex)
        //{
        //    speed = 0f;
        //    time += Time.deltaTime;
        //    Debug.Log("Time:" + time);
        //    if (time > 1f)
        //    {
        //        if (boolflag)
        //        {
        //            flag++;
        //            speed = 1;
        //            time = 0f;
        //            if (flag >= waypoints.Length)
        //            {
        //                flag = waypoints.Length - 2;
        //                boolflag = false;
        //            }
        //        }
        //        else
        //        {
        //            flag--;
        //            speed = 1;
        //            time = 0f;
        //            if (flag < 0)
        //            {

        //            }
        //        }
        //    }
        //}
    }
}
