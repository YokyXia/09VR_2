using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sage : MonoBehaviour
{
    public int cost = 30;
    public int feedback = 40;
    public GameObject effectPrefabA; // 特效预制件
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalData.Instance.sage && effectPrefabA != null)
        {
            effectPrefabA.SetActive(false);
        }
    }
    public void intensify()
    {
        if (cost <= GlobalData.Instance.lb && !GlobalData.Instance.sage)
        {
            GlobalData.Instance.lb -= cost;
            GlobalData.Instance.lb += feedback;
            GlobalData.Instance.sage = true;
            effectPrefabA.SetActive(true);
            Debug.Log("Sage on");
        }
    }
}
