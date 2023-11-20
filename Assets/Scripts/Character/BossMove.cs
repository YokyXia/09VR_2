using UnityEngine;

public class BossMove : MonoBehaviour
{
    public Transform[] waypoints;  // �洢�����˶����Transform���
    public float speed = 1f;  // ������˶��ٶ�

    private int currentWaypointIndex = 0;  // ��ǰ�˶��������
    private bool movingForward = true;  // �Ƿ������˶�
    private bool boolflag = true;
    public GameObject boss;
    private float time = 0f;
    private int flag = 0;

    private void Update()
    {
        // ��ȡ��ǰ�˶���
        Transform currentWaypoint = waypoints[currentWaypointIndex];

        // �������峯���˶���ķ���
        Vector3 direction = -(currentWaypoint.position - transform.position).normalized;

        // �������峯���˶��������ת�Ƕ�
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        // �������x�Ḻ��������Ϊ�˶�����
        boss.transform.rotation = Quaternion.Euler(-targetRotation.eulerAngles.x, -targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);

        // �����������һ��λ��
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);

        // �ƶ����嵽��һ��λ��
        transform.position = nextPosition;

        // �������ѽӽ���ǰ�˶��㣬���л�����һ���˶���
        if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.01f)
        {          // �л��˶�����
          
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
