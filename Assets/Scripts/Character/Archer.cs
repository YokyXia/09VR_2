using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Archer : MonoBehaviour
{
    // Start is called before the first frame update
    public int cost = 30;
    public float time_1 = 0f;
    public float time_2 = 0f;
    public GameObject player;
    public GameObject enemy;
    public float enemy_x;
    public float enemy_y;
    public float enemy_z;
    public float player_x;
    public float player_y;
    public float player_z;
    private Vector3 targetPosition = new Vector3(0.061f, 0.298f, 1.908f);

    //public GameObject arrow;
    //private float x=-10;
    //private float y=-10;
    //private float z=-10;


    public float speed = 20f;  //  移动速度
    public Transform target;  //  目标位置
    private Rigidbody rb;  //  物体的刚体组件
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (GlobalData.Instance.archer == true)
        //{
        //    time_1 += Time.deltaTime;
        //    if (time_1 > 15)
        //    {
        //        GlobalData.Instance.archer = false;
        //        time_1 = 0f;
        //        Debug.Log("archer off");
        //    }
        //}

        if (GlobalData.Instance.archer == true)
        {
            Debug.Log("判定到了1");
          //  enemy_x = enemy.transform.position.x;
          //  enemy_y = enemy.transform.position.y;
           // enemy_z = enemy.transform.rotation.z;
         //   player_x = player.transform.position.x;
         //   player_y = player.transform.position.y;
           // player_z = player.transform.rotation.z;
            
           // if ((player_x - enemy_x) * (player_x - enemy_x) + (player_y - enemy_y) * (player_y - enemy_y)+ (player_z - enemy_z) * (player_z - enemy_z) < 1.2 * 1.2*1.2)
            if(player.transform.position.z > 3.498f)
            {
                Debug.Log("判定到了2");
                if(GlobalData.Instance.archer == true)
                {
                    GetComponent<Rigidbody>().isKinematic = true;
                }
                else
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                }
               
                
                time_2 += Time.deltaTime;
                float t = Mathf.Clamp01(time_2 / 2);
                player.transform.localScale = Vector3.one * (1f - t);
                // Debug.Log("time2 is " + time_2);
                // player.transform.localScale=new Vector3(1+time_2*2,1+time_2*2,1+time_2*2);
                //  if (x == -10)
                //  {
                //  Debug.Log("1111111111");
                //  x = player.transform.position.x;
                //   y = player.transform.position.y;
                //    z = player.transform.position.z;
                //   }
                if (time_2 > 2)
                {
                    Debug.Log("22222222222");
                   
                  //  arrow.transform.position=new Vector3(x, y, z);
                  //  Debug.Log("po: " + arrow.transform.position);
                    
                    GlobalData.Instance.x = player.transform.position.x;
                    GlobalData.Instance.y = player.transform.position.y;
                    GlobalData.Instance.z = player.transform.position.z;
                    GlobalData.Instance.pos_flag = true;
                    Destroy(player);
                    //Vector3 direction = enemy.transform.position - arrow.transform.position;
                    //float distance = direction.magnitude;
                    //if (distance > 0.1f)  // 当距离大于0.1时，继续飞行
                    //{
                    //    Vector3 move = direction.normalized * 1f * Time.deltaTime;
                    //    transform.Translate(move);
                    //}
                    //else
                    //{
                    //   arrow.transform.position = new Vector3(-10,-10,-10);
                    //    x = -10;
                    //    y = -10;
                    //    z = -10;
                    //    time_2= 0;
                    //}
                }
                
            }
        }
    }

    public void intensify()
    {
        if (cost <= GlobalData.Instance.lb && !GlobalData.Instance.berserker && !GlobalData.Instance.archer)
        {
            GlobalData.Instance.lb -= cost;
            GlobalData.Instance.archer = true;
            Debug.Log("archer on");
        }
    }

    IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, target.position) > 0.01f)  //  只要物体和目标位置的距离大于0.01f,就一直移动
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed);  //  使用插值方法移动物体到目标位置
            rb.MovePosition(transform.position);  //  将物体的位置更新到刚体组件中
            yield return null;  //  继续下一次迭代
        }
    }
    private void MoveToPosition(Vector3 position, float moveSpeed)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, moveSpeed * Time.deltaTime);
        Debug.Log("gogogo");
    }

}
