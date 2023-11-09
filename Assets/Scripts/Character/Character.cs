using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject character; // ���ߵ�����
    public float minHeightY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DestroySelf();
    }

    /// <summary>
    /// ����һ���߶��Ի�
    /// </summary>
    void DestroySelf()
    {
        if (character.transform.position.y < minHeightY && SpawnManager.instance.isSageTime == false)
        {
            Destroy(character);
        }
    }

    /// <summary>
    /// �����Ի�
    /// </summary>
    public void HitDestroy()
    {
        Destroy(character);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<BossComponent>() != null)
        {
            Debug.Log("�����˺�");
            HitDestroy(); // �����Ի�
        }
        else
        {
            //Debug.Log("����Ŀ��");
        }
    }
}
