using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCookie : MonoBehaviour
{
    public Transform character; // ��ɫ�����λ������  
    public float randomRange = 0.5f; // ���λ�õķ�Χ 
    public float spawnInterval = 2.0f; // ���ɶ���ļ��ʱ�䣨�룩
    public int cookiesCount = 4; // ������������

    private Coroutine spawnCoroutine; // ����Э������

    // Start is called before the first frame update
    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnCookies()); // Э����������
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ÿ��2������һ������
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnCookies()
    {
        GameObject Cookie = Resources.Load<GameObject>("Character/Prefabs/Cookie");  // ����Դ�м�������Ԥ��  

        float randomProbability = UnityEngine.Random.value;

        while (randomProbability > 0.5 && GameObject.FindGameObjectsWithTag("Cookie").Length < cookiesCount) // ���������0.5�ҳ�����������С��һ������ʱ����
        {
            yield return new WaitForSeconds(spawnInterval);

            // ��ȡ��ɫ��ǰλ��  
            Vector3 characterPosition = character.position;

            // �������ƫ����  
            float randomX = UnityEngine.Random.Range(-randomRange, randomRange);
            float randomZ = UnityEngine.Random.Range(-randomRange, randomRange);

            // �����µ����λ��  
            Vector3 randomPosition = new Vector3(characterPosition.x + randomX, characterPosition.y, characterPosition.z + randomZ);

            // �ڸ�λ�����ɶ���ʵ�� 
            Instantiate(Cookie, randomPosition, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0));
        }
    }
}
