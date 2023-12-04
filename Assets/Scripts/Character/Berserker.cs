using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : MonoBehaviour
{
    // Start is called before the first frame update

    public int cost = 40;
    public float time1 = 0f;
    public GameObject effectPrefab; // 特效预制件
    //private bool shouldTriggerEffect = false; // 触发特效的条件




    // Update is called once per frame
    void Update()
    {
        //if (GlobalData.Instance.berserker == true)
        //{
        //    time1 += Time.deltaTime;
        //    if (time1 > 10)
        //    {
        //        GlobalData.Instance.berserker = false;
        //        time1 = 0f;
        //        Debug.Log("berserker off");
        //    }
        //}

        if (GlobalData.Instance.berserker == false && effectPrefab!=null)
        {
            effectPrefab.SetActive(false);
        }
    }

    public void intensify()
    {
        if (cost <= GlobalData.Instance.lb && !GlobalData.Instance.archer && !GlobalData.Instance.berserker)
        {
            GlobalData.Instance.lb-=cost;
            GlobalData.Instance.berserker = true;
            effectPrefab.SetActive(true);
            //shouldTriggerEffect = true; // 设置为触发特效的条件

            Debug.Log("berserker on");
        }
    }
}
