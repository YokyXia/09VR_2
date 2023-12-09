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

    public GameObject effectPrefabA; // ��ЧԤ�Ƽ�

    //public GameObject arrow;
    //private float x=-10;
    //private float y=-10;
    //private float z=-10;


    public float speed = 20f;  //  �ƶ��ٶ�
    public Transform target;  //  Ŀ��λ��
    private Rigidbody rb;  //  ����ĸ������


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

        if (GlobalData.Instance.archer == false && effectPrefabA != null)
        {
            effectPrefabA.SetActive(false);
        }

        if (GlobalData.Instance.archer == true)

        {
            Debug.Log("�ж�����1");
            if(player.transform.position.z > 2.498f || player.transform.position.x < -2.64f || player.transform.position.x >2.23f)
            {
                Debug.Log("�ж�����2");
                if(GlobalData.Instance.archer == true && !GlobalData.Instance.pos_flag)//ע������ͣ����С
                {
                   // GetComponent<Rigidbody>().isKinematic = true;
                }
                else
                {
                  //  GetComponent<Rigidbody>().isKinematic = false;
                }
               
                
               // time_2 += Time.deltaTime;
             //   float t = Mathf.Clamp01(time_2 / 2);
              //  player.transform.localScale = Vector3.one * (1f - t);
                
            //    if (time_2 > 2)
                {
                    Debug.Log("22222222222");
                   
                 
                    
                    GlobalData.Instance.x = player.transform.position.x;
                    GlobalData.Instance.y = player.transform.position.y;
                    GlobalData.Instance.z = player.transform.position.z;
                    GlobalData.Instance.pos_flag = true;
                    Destroy(player);
                    
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
            effectPrefabA.SetActive(true);
            Debug.Log("archer on");
        }
    }

    IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, target.position) > 0.01f)  //  ֻҪ�����Ŀ��λ�õľ������0.01f,��һֱ�ƶ�
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed);  //  ʹ�ò�ֵ�����ƶ����嵽Ŀ��λ��
            rb.MovePosition(transform.position);  //  �������λ�ø��µ����������
            yield return null;  //  ������һ�ε���
        }
    }
    private void MoveToPosition(Vector3 position, float moveSpeed)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, moveSpeed * Time.deltaTime);
        Debug.Log("gogogo");
    }

}
